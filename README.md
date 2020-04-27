# KeytorcTest

Altyapı ve Sistem Gereksinimleri

Visual Studio 2019 IDE'si kullanılarak kodlanmıştır.
Selenium WebDriver Chrome sürümü 81.0.0;
Selenium Sürümü 3.141.0
NUnit sürümü 3.12

Testin çalıştığı class: NeedToFunctions;
Değişkenlerin ve fonksiyoların bulunduğu Class: MyVariable;
Hangi fonksiyonlara ihtiyacımın olduğu hatırlatıcı Interface :INeedToFunctions.

Uygulamanın Genel Hatları ve amacı;

Uygulama n11.com sitesini ziyaret eder, kullanıcı girişi yapar, "samsung" kelimesini aratır, çıkan sonuçlardan 2. sayfa 3. ürünü favorilere ekler. Daha sonra bu ürünü favorilerden kaldırır. Her bir işlem sonrası uygulama doğrulama yapmalıdır.

Doğrulamalar 2  farklı türde yapılmıştır. Bir kısmında ekran görünütüsü alınırken diğer kısım da Assert.IsTrue dengesi üzerinden Verify fonksiyonu ile sağlanmaktadır. Her doğrulama ve adım sonrasında o adım için oluşturulan dosyaya ve log kayıtlarına bilgi yollanır. Ekran görüntüleri ile dosyalar Masaüstünüze kurulacak olan "ScreenShots" isimli klasöre kaydedilecektir.

Dikkat Edilmesi Gerekenler!!!

Web sayfasına şu an bu uygulama ile kullanıcı girişi yapılamamaktadır. Eğer debug yöntemi kullanır ve "Verify(UserName(),"zeynep Dinç", "Giriş başarısız!");" satırına Kesme noktası eklerseniz. Girişi uygulamada belirtilen emailName ve passwordName ile yapabilirsiniz. Kendi oturumunuzu açmak isterseniz Verify fonksiyonundaki "zeynep Dinç" yerine kendi kullanıcı ad soyadınız, emailName değişkenine kendi e-mailinizi ve passwordName değişkenine kendi şifrenizi kaydetmeyi unutmayınız. 
