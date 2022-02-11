using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using System.Web.Script.Serialization;
using FinalProject.common;
using System.Configuration;

namespace FinalProject.Controllers
{
    public class CartController : Controller
    {
        FinalProjectDBEntities db = new FinalProjectDBEntities();
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return View(list);
        }

        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(string id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.product.ProductID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.product.ProductID == item.product.ProductID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public ActionResult AddItem(string productId, int quantity)
        {

            var product = db.SanPhams.FirstOrDefault(c => c.ProductID == productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.product.ProductID == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.product.ProductID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.product = product;
                item.Quantity = quantity;

                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address, string email)
        {
            var order = new Order();
            order.CreatedDate = DateTime.Now;
            order.ShipAddress = address;
            order.ShipMobile = mobile;
            order.ShipName = shipName;
            order.ShipEmail = email;
            order.Status = "Chờ xử lý";

            try
            {
                db.Orders.Add(order);
                db.SaveChanges();
                //Thêm Order               

                var id = order.OrderID;

                var cart = (List<CartItem>)Session[CartSession];

                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.product.ProductID;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.product.GiaBan;
                    orderDetail.Quantity = item.Quantity;
                    db.OrderDetails.Add(orderDetail);
                    db.SaveChanges();
                    total += (item.product.GiaBan.GetValueOrDefault(0) * item.Quantity);
                }
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Contents/template/neworder.html"));

                content = content.Replace("{{CustomerName}}", shipName);
                content = content.Replace("{{Phone}}", mobile);
                content = content.Replace("{{Email}}", email);
                content = content.Replace("{{Address}}", address);
                content = content.Replace("{{Total}}", total.ToString());
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();



                new MailHelper().SendMail(email, "HyperX: Đơn hàng thành công", content);
                new MailHelper().SendMail(toEmail, "HyperX: Đơn hàng thành công", content);
                //Xóa hết giỏ hàng
                Session[CartSession] = null;
            }
            catch (Exception ex)
            {
                //ghi log
                return Redirect("/Cart/UnSuccess");
            }
            return Redirect("/Cart/Success");
        }

        public ActionResult Success()
        {
            return View();
        }
        public ActionResult UnSuccess()
        {
            return View();
        }



    }
}