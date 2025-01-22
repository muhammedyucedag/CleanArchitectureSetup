# 2025 Yılı Clean Architecture Setup

Bu repoda, 2025 yılı için projelerimizde başlangıç olarak kullanabileceğiniz modern ve modüler bir Clean Architecture yapısı sunulmaktadır.

## Proje İçeriği

### Mimari Yapı
- **Architectural Pattern**: Clean Architecture
- **Design Patterns**:
  - Result Pattern
  - Repository Pattern
  - CQRS Pattern
  - UnitOfWork Pattern

### Kullanılan Kütüphaneler
- **MediatR**: CQRS ve mesajlaşma işlemleri için.
- **TS.Result**: Standart sonuç modellemeleri için.
- **AutoMapper**: Nesne eşlemeleri için.
- **FluentValidation**: Doğrulama işlemleri için.
- **TS.EntityFrameworkCore.GenericRepository**: Genel amaçlı repository işlemleri için.
- **EntityFrameworkCore**: ORM (Object-Relational Mapping) için.
- **Scrutor**: Dependency Injection yönetimi ve dinamik servis kaydı için.

## Kurulum ve Kullanım
1. **Depoyu Klonlayın**:
   ```bash
   git clone https://github.com/muhammedyucedag/CleanArchitectureSetup
