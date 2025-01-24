# GKATELİERS
## EMEĞİ GEÇENLER 
- Firdevs Kaya 132130081
- Caner Enis 132130082
- Ulaş Ataş 132130046

## PROJENİN ÖZELLİKLERİ
Kişiselleştirilebilir ürünlerin satıldığı, Asp.Net 8.0 MVC tabanlı e-ticaret sitesi projesi.

## SİTENİN KULLANIMI 

## Ana sayfa
Ana sayfa siteye girdiğimizde bizi karşılar. Bu sayfada üzerinde;
- Ürünlerimizin tanıtımları yapılıyor.

![image](https://github.com/user-attachments/assets/aca3474e-435d-4a33-9122-741ef2dbb204)

## Hakkımızda Sayfası
Hakkımızda sayfasında işletmemizin hikayesi bulunuyor. Ayrıca iletişim bilgileri ve işletmemizin konumunu gösteren harita da sayfanın alt kısmında yer alıyor.

![image](https://github.com/user-attachments/assets/d7662ec5-e250-4026-b0d2-8640ef017eae)

## Ürünler Sayfası
Ürünler sayfasında veri tabanına kaydedilen ürünlerimiz listelenir. Bu sayfa üzerinden;
- Detaylar butonuna tıklayarak ürünlerin detaylarının bulunduğu sayfaya erişilebiliyor.
- Sepete ekle butonuna tıklayarak ürünler sepete eklenebiliyor.
- Satın al butonuna tıklayarak direkt satın alma sayfasına yönlendiriliyoruz.

(Satın al ve sepete ekle butonu üye girişi yapılmışsa işlevsel hale geliyor eğer üye girişi yapılmamışsa giriş yap sayfasına yönlendiliriliyoruz.)

![image](https://github.com/user-attachments/assets/50e93f6c-b6d5-459d-a520-cf2e43499d72)

## Ürün Detay Sayfası
Detaylar sayfası üzerinde veri tabanından alınan ürün özellikleri sergilenir. Bu sayfa üzerinden;
- Satın al butonuna tıklayarak direkt satın alma sayfasına yönlendiriliyoruz.
- Sepete ekle butonuna tıklayarak ürünler sepete eklenebiliyor.

(Satın al ve sepete ekle butonu üye girişi yapılmışsa işlevsel hale geliyor eğer üye girişi yapılmamışsa giriş yap sayfasına yönlendiliriliyoruz.)

![image](https://github.com/user-attachments/assets/b61f419f-cb76-4e93-b487-ab863aaa538f)

## Sepet Sayfası
Sepet sayfası üzerinde sepete eklediğimiz ürünler listelenir. Bu sayfa üzerinden;
- Sepete eklediğimiz ürünlerin adedini satın almak istediğimiz miktar kadar arttırabiliyor veya azaltabiliyoruz. Bu arttırma ve azaltma işleminde toplam fiyat anlık olarak değişiyor.
- Çöp kovası ikonuna tıklayarak ürünü sepetten kaldırabiliyoruz.
- Sepeti Temizle butonuna tıklayarak tüm sepeti temizleyebiliyoruz.
- Siparişi Tamamla butonuna tıklayarak satın alma ekranına yönlendiliyoruz.
- Alışverişe Devam Et butonuna tıklayarak ürünler sayfasına geri dönüp alışverişe devam edebiliyoruz.
- Eğer sepet boş ise alışverişe başlamak için tıklayın yazısına tıklayarak ürünler sayfasına yönlendiliyoruz.

(Sepet sayfasına navbardaki alışveriş sepeti simgesine tıklayarak ulaşıyoruz. Eğer üye girişi yapılmamışsa bu simge navbar da görünmüyor.)

![image](https://github.com/user-attachments/assets/11713c12-9d2f-41d2-9924-4e8ea25ec467)

## Satın Al Sayfası
Satın al sayfası üzerinde müşterinin teslimat ve ödeme bilgileri alınır. Ayrıca sipariş özeti görüntülenir. 
(Şuan bu sayfa işlevsiz durumda)

![image](https://github.com/user-attachments/assets/23fa1906-51d1-421e-b65a-97b8d3353c6c)

## Giriş Yap Sayfası
Giriş sayfası üzerinde E-posta ve şifre bilgileri istenir. Bu sayfa üzerinden;
- Girilen E-posta ve şifre bilgileri giriş yap butonuna tıkladıktan sonra veri tabanında kayıtlı olup olmadığı kontrol edilir. Bilgileri girilen kişinin rolüne bakılarak üye veya admin girişi yapılır.
- Kullanıcı, şifremi unuttum yazısına tıklayarak şifremi unuttum sayfasına yönlendirilir.
- Kullanıcı, hesap oluştur yazısına tıklayarak üye ol sayfasına yönlendirilir.

(Google ve Facebook ile devam et butonları işlevsiz durumda)

![image](https://github.com/user-attachments/assets/a8872462-1711-404b-982c-9d3fa66c997d)

## Şifremi Unuttum Sayfası
Şifremi unuttum sayfasında kullanıcı kendisine ait E-posta ve telefon numarasını girer. Eğer E-posta ve telefon numarası uyuşmuyorsa şifre sıfırlama işlemi gerçekleşmez. Bu şartlar sağlandıktan sonra kullanıcı yeni şifresini iki kez yazıp şifreyi sıfırla butonuna basarak şifresini güncellemiş olur. 

![image](https://github.com/user-attachments/assets/f9ecbf81-2050-4e11-8cbd-4d6941b025ee)

## Üye Ol Sayfası
Üye ol sayfası üzerinden kullanıcı üyelik işlemlerini gerçekleştirir. Bu sayfa üzerinden;
- Kullanıcı; ad, soyad, E-Posta, Telefon, ve belirlediği şifreyi iki kez girer.
- Üye ol butonuna basmadan önce üyelik sözleşmesi kabul edilmelidir.
- Üyelik sözlesşmesi kabul edildikten sonra üye ol butonuna tıklanarak forma doldurulan bilgiler veri tabanına kayıt edilir ve üyelik işlemi gerçekleşir.
- Kullanıcı, önceden hesap oluşturmuşsa giriş yap sayfasına tıklayarak giriş sayfasına yönlendirilir.
(Google ve Facebook ile devam et butonları işlevsiz durumda)

![image](https://github.com/user-attachments/assets/21d41885-4b5e-4daa-814e-ebd0942bb273)

## Ayarlarım Sayfası
Ayarlarım sayfası üzerinden kullanıcı hesap ve adres bilgilerini güncelleyebilir.
- Güncel hesap bilgileri otomatik olarak alanlara doldurulur değişiklik yapılmak istenen bilgiler değiştirilip değişiklikleri kaydet butonuna tıklanarak yeni bilgiler veri tabanına kaydedilir.
- Kullanıcı adres bilgilerini girip, Adres bilgilerini güncelle butonuna basarak adres bilgilerini veri tabanına kayıt etmiş olur.
(Siparişlerim ve favorilerim seklemeleri işlevsiz durumda)

![image](https://github.com/user-attachments/assets/87f52c9a-5909-488b-8dd6-cee35d2db0d0)

## Admin Paneli
Admin paneli üzerinden ürünleri yönet diyerek ürün yönetimi sayfasına erişim sağlanır.
(Admin paneline sadece rolü admin olan kullanıcılar erişim sağlayabilir.)

![image](https://github.com/user-attachments/assets/ec426673-0459-42a9-8105-a366fc14f26d)

## Ürün Yönetimi Sayfası
Ürün yönetimi sayfasında veri tabanına kaydettiğimiz ürünler listeleniyor. Bu sayfa üzerinden;
- Sil butonuna tıklayarak veri tabanında kayıtlı olan bir ürünü silebiliyoruz.
- Yeni ürün ekle butonuna tıklayarak veri tabanına yeni ürün ekleyebildiğimiz sayfaya yönlendiriliyoruz. 

![image](https://github.com/user-attachments/assets/57cc2f90-04b7-472e-8c08-cdc4dfc6a732)

## Yeni Ürün Ekle Sayfası
Yeni ürün ekle sayfasında eklemek istediğimiz ürünün bilgilerini yazıp ve ürün resminin url ini girip ürün ekle butonuna tıklayarak ürünümüzü veri tabanına kaydetmiş oluyoruz. Kaydedilen ürünler ürünler sayfasında listeleniyor.

![image](https://github.com/user-attachments/assets/0e063993-cc23-4d8c-b46f-44c083603f73)




