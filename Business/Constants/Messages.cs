using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ActorNameInvalid = "Aktör ismi ve soy ismi minimum 3 karakterden oluşmalıdır.";
        public static string ActorIsNotSuitable = "Aktör zaten bir projede görev alıyor.";
        public static string InvalidValue = "Lütfen geçerli bir değer giriniz.";
        public static string OperationSuccessful = "İşlem başarıyla gerçekleştirildi.";
        public static string MaintenanceTime = "Sistem şuan bakımda";
        public static string AuthorizationDenied = "Yetki Yok !";
        public static string ImageLimitExpiredForCar = "Bir arabaya maximum 5 fotoğraf eklenebilir";
        public static string InvalidImageExtension = "Geçersiz dosya uzantısı, fotoğraf için kabul edilen uzantılar : .JPG .JPEG .PNG.TIF .TIFF .GIF .BMP .ICO" ;
        //public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };
        public static string CarImageMustBeExists = "Böyle bi resim bulunamadı";
    }
}
