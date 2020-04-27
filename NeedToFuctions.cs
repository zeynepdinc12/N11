using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using NUnit.Framework;
using System;
using System.IO;

namespace KeytorcTest
{
    [TestClass]
    class NeedToFuctions : MyVariable
    {

        /// <summary>
        /// Başlangıç fonksiyonu temel işlemleri yapmaktadır.
        /// Bu işlemler sırasıyla;
        /// 1) Url adresine gidilmesi,
        /// 2) Ekran ilk açıldığında çıkan bilgilendirme pop-up'ını "tamam" butonuna basarak kapatma
        /// 3) Çerez politikası bilgilendirmesini kapatma
        /// 4) Sayfanın ekran görüntüsü alarak Masaüstünüzde oluşturacağı "ScreenShoots" klasörüne "Home.png"
        /// kayıt gerçekleştirir.
        /// 5) Sayfanın sloganı üzerinden sayfa doğrulaması yapma
        /// şeklindedir. Eğer herhangi bir doğrulama sorunu olursa "Yanlış adrese gidildi" şeklinde hata mesajları
        /// verilecektir.
        /// Bir sorun olmaması durumunda aşağıda bulunan "N11.com sayfasına giriş sağlandı Adım 1 başarılı.
        /// Adım 2 Başlatılıyor:" mesajlaı döndürülür
        /// </summary>
        [OneTimeSetUp]
        public void Baslangic()
        {
            BasicSettings();
            Verify(Slogan(), "alışverişin uğurlu adresi", "Yanlış bir adrese gidildi");
            FileProcesses("Slogan","N11.com sayfasına giriş sağlandı Adım 1 başarılı. Adım 2 Başlatılıyor:");
            Logger.LogMessage("N11.com sayfasına giriş sağlandı Adım 1 başarılı. Adım 2 Başlatılıyor:");
        }
        /// <summary>
        /// İşlemlerde sırasıyla öncelikle;
        ///     LoginProcesses: "Giriş Yap" butonuna tıklanır gelen ekranda önce email adresi daha sonra şifre girilir. 
        /// Kayıt ol butonuna basılır. Burada şöyle bir sorunla karşılaştım. Her ne kadar "Giriş Yap" butonuna basılsa
        /// veya enter tuşuna tıklanırsa tıklansın Giriş yapılamıyor. Birkaç araştırma ve yol deneme sonrası bu durum
        /// iki durum söz konusu
        /// ilk durum web sayfası üzerinden otomasyonla girişe izin verilmediği yönünde ki 
        /// (incele kısmından sayfa kontrol edildiğinde gerek bir takım Javascript kodlarından bazı dosyaları inceledim.
        /// Şu an başka bir bilgisayarda otomasyonu deneyemediğim için herhangi bir kesin yargı içinde bulunamıyorum)
        /// ikinci durum ben bu hatanın henüz doğru nedenini ve buna bağlı cevabını bulabilmiş değilim.
        /// Buradaki doğrulama yöntemi "Giriş Yap" kelimesi yerine "zeynep Dinç" kelimelerini bekliyor
        /// fakat giriş yapılamadığı için işlem hata veriyor ve test sonlandırılmakta.
        /// Buradan sonrası için ise eğer Verify fonksiyonunu yorum satırına alırsanız;
        ///     SearchProcesses: "Samsung" kelimesi aratılıyor. 2 doğrulama var biri ekmek kırıntıları 
        /// üzerinden samsung yazısını görmesi diğeri ise ekran görüntüsü alarak kaydetmesi şeklindedir.
        ///     SelectProcesses: 2. sayfada bulunan 3. ürüne gidilir. Favorilere ekle butonuna basılır. Manuel testte
        /// daha önce giriş yapıldığı için listeye eklenir. Otomasyon testinde yukarıda belirttiğim sorunlardan kaynaklı
        /// tekrar giriş yap ekranı gelmektedir.
        ///     MoveToFavorite: ile son olarak Kullanıcı Adı-> Favoriler-> ürün seçilir. Açılan ekrandan "Sil" linkine 
        /// tıklanır. Daha sonra ekranda çıkacak olan "Ürünüz silindi" mesajı beklenir. Bundan sonra ekran görüntüsü
        /// alınır ve mesaj kapatılır.
        /// </summary>
        [Test]
        public void Islemler()
        {   LoginProcesses();
            Verify(UserName(), "zeynep Dinç", "Kullanıcı Girişi Başarısız");
            FileProcesses("UserName","Kullanici girisi saglandi. Adim 2 basarili. Adim 3 baslatiliyor:");
            Logger.LogMessage("Kullanici girisi saglandi Adim 2 basarili. Adim 3 Baslatiliyor:");
            SearchProcesses();
            Verify(BreadCrumb(), "samsung", "Urun ismi dogru aratilamadi");
            FileProcesses("BreadCrumb","Urün aratildi ve kayit kontrol edildi. Adim 3 başarili. Adim 4 Baslatiliyor:");
            Logger.LogMessage("Ürün aratıldı ve  kayıt kontrol edildi. Adım 3 başarılı. Adım 4 Başlatılıyor:");
            SelectProcesses();
            FileProcesses("SelectProcesses","2. sayfaya gecildi. Bu durum ekran goruntusu alinarak dogrulandi.Urun favorilere eklendi.Adim 4 başarili. Adim 5 başlatiliyor");
            Logger.LogMessage("2. sayfaya geçildi. Bu durum ekran görüntüsü alınarak doğrulandı.Ürün favorilere eklendi.Adım 4 başarılı. Adım 5 başlatılıyor");
            MoveToFavorite();
            FileProcesses("MoveToFavorite","Urun favorilere kaldırıldı.Buna iliskin ekran goruntusu alindi ve dogrulama saglandi.Adim 5 basarili.");
            Logger.LogMessage("urun favorilerden kaldırıldı.Adım 5 başarılı.");
        }
        /// <summary>
        /// Test işlemleri bitirilir ve ekran kapatılır.
        /// </summary>
        [TearDown]
        public void KapatmaIslemi()
        {
            CloseTest();
        }     
    }
}