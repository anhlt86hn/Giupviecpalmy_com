using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GiupviecPalmy_com
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(name: "Home", url: "", defaults: new { controller = "Home", action = "Index" });
            routes.MapRoute("Menu giới thiệu", url: "gioi-thieu", defaults: new { controller = "GioiThieu", action = "Index" });
            routes.MapRoute("Chi tiết giới thiệu", url: "gioi-thieu/{tag}", defaults: new { controller = "GioiThieu", action = "Detail" });
            
            routes.MapRoute("Menu Dịch vụ", url: "dich-vu", defaults: new { controller = "DichVu", action = "Index" });
            routes.MapRoute("Nhóm Dịch vụ", url: "dich-vu/{tag}", defaults: new { controller = "DichVu", action = "Detail" });
           
            routes.MapRoute("Menu tuyển dụng", url: "tuyen-dung", defaults: new { controller = "TuyenDung", action = "Index" });
            routes.MapRoute("Chi tiết tuyển dụng", url: "tuyen-dung/{tag}", defaults: new { controller = "TuyenDung", action = "Detail" });
            //routes.MapRoute("Menu Tin tức", url: "tin-tuc", defaults: new { controller = "TinTuc", action = "Index" });
            routes.MapRoute("Menu con của menu Tin tức", url: "tin-tuc/{tag}", defaults: new { controller = "TinTuc", action = "Detail" });
            
            routes.MapRoute("Menu Khuyến mại", url: "khuyen-mai", defaults: new { controller = "KhuyenMai", action = "Index" });
            routes.MapRoute("Menu con của menu Khuyến mại", url: "khuyen-mai/{tag}", defaults: new { controller = "KhuyenMai", action = "Detail" });          
            //routes.MapRoute("Menu Quy trinh", "quy-trinh", new { controller = "QuyTrinh", action = "Index" });
            //routes.MapRoute("Chi tiết quy trinh", url: "quy-trinh/{tag}", defaults: new { controller = "QuyTrinh", action = "Detail" });
            routes.MapRoute("Liên hệ", url: "lien-he", defaults: new { controller = "LienHe", action = "Index" });
            
            //routes.MapRoute("Menu Gioi thieu", url: "gioi-thieu/{tag}", defaults: new { controller = "Default", action = "ProductionArticle" });
            //routes.MapRoute("Menu Quy trinh", url: "quy-trinh/{tag}", defaults: new { controller = "Default", action = "ProcessArticle" });

            //routes.MapRoute("Menu-Category Bản tin Palmy Vietnam", url: "tin-tuc", defaults: new { controller = "NewsView", action = "NewsPage" });
            //routes.MapRoute("Menu-Category Bản tin nội bộ", url: "tin-tuc/noi-bo/", defaults: new { controller = "NewsView", action = "InternalPage" });
            //routes.MapRoute("Post Bản tin nội bộ", "tin-tuc/noi-bo/{tag}/{*catchall}", new { controller = "NewsView", action = "NewsPageDetail", tag = UrlParameter.Optional }, new { controller = "^N.*", action = "^NewsPageDetail$" });
            //routes.MapRoute("Menu-Category Tin tức sự kiện", url: "tin-tuc/su-kien/", defaults: new { controller = "NewsView", action = "EventPage" });
            //routes.MapRoute("Post Tin tức sự kiện", "tin-tuc/su-kien/{tag}/{*catchall}", new { controller = "NewsView", action = "NewsPageDetail", tag = UrlParameter.Optional }, new { controller = "^N.*", action = "^NewsPageDetail$" });

            //routes.MapRoute("Menu-Category Cẩm nang gia đình", url: "cam-nang", defaults: new { controller = "NewsView", action = "FamilyHandBook" });
            //routes.MapRoute("Menu-Category Mẹo vặt gia đình", url: "cam-nang/meo-vat/", defaults: new { controller = "NewsView", action = "FamilyTips" });
            //routes.MapRoute("Post Mẹo vặt gia đình", "cam-nang/meo-vat/{tag}/{*catchall}", new { controller = "NewsView", action = "FamilyHandBookDetail", tag = UrlParameter.Optional }, new { controller = "^N.*", action = "^FamilyHandBookDetail$" });
            //routes.MapRoute("Menu-Category Sức khỏe gia đình", url: "cam-nang/suc-khoe/", defaults: new { controller = "NewsView", action = "Health" });
            //routes.MapRoute("Post Sức khỏe gia đình", "cam-nang/suc-khoe/{tag}/{*catchall}", new { controller = "NewsView", action = "FamilyHandBookDetail", tag = UrlParameter.Optional }, new { controller = "^N.*", action = "^FamilyHandBookDetail$" });
            //routes.MapRoute("Menu-Category Góc nội trợ", url: "cam-nang/noi-tro/", defaults: new { controller = "NewsView", action = "HomeMaker" });
            //routes.MapRoute("Post Góc nội trợ", "cam-nang/noi-tro/{tag}/{*catchall}", new { controller = "NewsView", action = "FamilyHandBookDetail", tag = UrlParameter.Optional }, new { controller = "^N.*", action = "^FamilyHandBookDetail$" });
            //routes.MapRoute("Menu-Category Chuyện cuộc sống", url: "cam-nang/cuoc-song/", defaults: new { controller = "NewsView", action = "LifeStory" });
            //routes.MapRoute("Post Chuyện cuộc sống", "cam-nang/cuoc-song/{tag}/{*catchall}", new { controller = "NewsView", action = "FamilyHandBookDetail", tag = UrlParameter.Optional }, new { controller = "^N.*", action = "^FamilyHandBookDetail$" });
            
            //routes.MapRoute("Menu Tuyen dung", url: "tuyen-dung/{tag}", defaults: new { controller = "Default", action = "RecruitmentArticle" });
            
            //routes.MapRoute("Product", "san-pham/{*catchall}", new { controller = "Default", action = "Album", tag = UrlParameter.Optional }, new { controller = "^D.*", action = "^Album$" });
            //routes.MapRoute("Ho so nhan vien", url: "nhan-vien", defaults: new { controller = "Default", action = "Albums"});
            //routes.MapRoute("Ho so nhan vien page", url: "nhan-vien/{page}", defaults: new { controller = "Default", action = "Albums"});


            routes.MapRoute(name: "menu", url: "{tag}", defaults: new { controller = "Default", action = "Menu" });
            //routes.MapRoute(name: "buy", url: "Home/checkout", defaults: new { controller = "Home", action = "checkout" });
            #region[Admin]
            routes.MapRoute("Admin", "Admins/admins/{*catchall}", new { controller = "Admins", action = "admins", tag = UrlParameter.Optional }, new { controller = "^A.*", action = "^admins$" });
            routes.MapRoute("Logout", "Admins/Logout/{*catchall}", new { controller = "Admins", action = "Logout", tag = UrlParameter.Optional }, new { controller = "^A.*", action = "^Logout$" });
            routes.MapRoute("AdminDefault", "Admins/Default/{*catchall}", new { controller = "Admins", action = "Default", tag = UrlParameter.Optional }, new { controller = "^A.*", action = "^Default$" });
            #endregion
                       
            //routes.MapRoute("Trang tin tuc", "ban-tin-palmy-vietnam/{tag}/{*catchall}", new { controller = "NewsView", action = "News", tag = UrlParameter.Optional }, new { controller = "^N.*", action = "^News$" });
            //routes.MapRoute("Bao gia", "bao-gia/{*catchall}", new { controller = "NewsView", action = "CostList", tag = UrlParameter.Optional }, new { controller = "^N.*", action = "^CostList$" });
            routes.MapRoute(name: "Default", url: "{controller}/{action}/{id}", defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}