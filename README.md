# SteamBlocker

Bu basit Windows Forms uygulaması, tek bir tıklamayla Steam istemcisinin internet erişimini engellemenize veya yeniden etkinleştirmenize olanak tanır. Bu, özellikle oyun oynarken dikkatinizin dağılmasını önlemek veya bant genişliğinizi diğer uygulamalar için serbest bırakmak istediğiniz durumlar için faydalı olabilir.

## Nasıl Çalışır?

Uygulama, Windows Güvenlik Duvarı'nda "SteamEngelle" adında bir kural oluşturur (eğer yoksa) ve bu kuralı etkinleştirerek veya devre dışı bırakarak Steam'in internet bağlantısını kontrol eder.

* **Eğer kural etkinse:** Steam'in internete giden bağlantısı engellenir. Uygulama arayüzünde kırmızı bir gösterge ve "Steam Erişime Kapalı!" metni görüntülenir. "Aç!" butonuna tıklayarak kuralı devre dışı bırakabilirsiniz.
* **Eğer kural devre dışıysa veya yoksa:** Steam'in internete giden bağlantısı açıktır. Uygulama arayüzünde yeşil bir gösterge ve "Steam Erişime Açık!" metni görüntülenir. "Kapat!" butonuna tıklayarak kuralı etkinleştirebilirsiniz.

Uygulama, arka planda düzenli olarak (3 saniyede bir) güvenlik duvarı kuralının durumunu kontrol eder ve kullanıcı arayüzünü buna göre günceller.

**Not:** Uygulamanın düzgün çalışabilmesi için Steam'in varsayılan kurulum dizininde (`C:\Program Files (x86)\Steam\steam.exe`) kurulu olması gerekmektedir.

## Kullanım

1.  Uygulamanın çalıştırılabilir dosyasını (`.exe`) açın.
2.  Uygulama penceresinde mevcut Steam erişim durumu görüntülenecektir.
3.  Steam'in internet erişimini değiştirmek için büyük butona tıklayın ("Kapat!" veya "Aç!").

## Gereksinimler

* Windows işletim sistemi.
* .NET Framework (genellikle Windows'ta kurulu gelir).
* Steam istemcisinin varsayılan dizinde kurulu olması (`C:\Program Files (x86)\Steam\steam.exe`).

## Bilinen Sorunlar

* Şu anda, Steam'in farklı bir dizine kurulduğu durumlar desteklenmemektedir. (Kodda el ile düzenleyebilirsiniz!)

## Lisans

Bu proje [MIT Lisansı](LICENSE) altında lisanslanmıştır.

## Sorumluluk Reddi

BU YAZILIM "OLDUĞU GİBİ" ESASINDA, HERHANGİ BİR AÇIK VEYA ZIMNİ GARANTİ OLMAKSIZIN SUNULMAKTADIR. YAZARLAR VEYA TELİF HAKKI SAHİPLERİ, YAZILIMIN KULLANIMINDAN, VERİ KAYBINDAN VEYA DİĞER ZARARLARDAN KAYNAKLANAN HİÇBİR İDDİA, ZARAR VEYA DİĞER YÜKÜMLÜLÜKLERDEN SORUMLU DEĞİLDİR.
