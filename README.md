# MENUAPI - ระบบจัดการเมนูอาหารและคำนวณต้นทุนวัตถุดิบ (RESTful Web API)

RESTful Web API สำหรับบริหารจัดการเมนูอาหาร การควบคุมวัตถุดิบ และระบบคำนวณต้นทุนต่อจานอัตโนมัติ พัฒนาด้วย ASP.NET Core (.NET) และ Entity Framework Core ร่วมกับ SQL Server ออกแบบตามหลัก Layered Architecture เพื่อรองรับการเชื่อมต่อกับระบบภายนอกทั้ง Web, Mobile และ Desktop Application

---

## ภาพรวมโปรเจกต์ (Project Overview)

**MENUAPI** เป็น Core Service กลางที่พัฒนาขึ้นเพื่อจัดการตรรกะทางธุรกิจ (Business Logic) ด้านสูตรอาหารและการคำนวณต้นทุนการผลิตจริง โดยเชื่อมโยงความสัมพันธ์แบบกลุ่มต่อกลุ่ม (Many-to-Many Architecture) ระหว่างรายการอาหารกับวัตถุดิบ ผ่านโครงสร้าง Composite Key พร้อมกลไก **Auto Recalculation Engine** ที่คำนวณต้นทุนรวม (`TotalPrice`) ให้แบบ Real-time ทุกครั้งที่มีการเพิ่ม แก้ไข หรือถอดถอนวัตถุดิบออกจากเมนู

---

## คุณสมบัติหลักของระบบ (Key Features)

* **การจัดการแบบ RESTful ครบวงจร (Full CRUD Operations):**
  * **Menu Controller:** จัดการรายการอาหารและเครื่องดื่ม (สร้าง, ดึงรายการทั้งหมด, ค้นหาตาม ID, แก้ไข, ลบ)
  * **Material Controller:** จัดการรายการวัตถุดิบ สต็อก และราคาต่อหน่วย
  * **MenuMaterial Controller:** จัดการการผูกสูตรวัตถุดิบเข้ากับเมนู อัปเดตปริมาณ และถอดวัตถุดิบออกจากสูตร
* **ระบบคำนวณต้นทุนอัตโนมัติ (Automated Cost Recalculation):** ประมวลผลคำนวณผลรวมต้นทุนของเมนูใหม่ทันทีเมื่อมีการเปลี่ยนแปลงโครงสร้างสูตรอาหาร
* **การตรวจสอบความถูกต้องของข้อมูล (Data Validation & Integrity):** ป้องกันข้อผิดพลาดจากการใส่ Foreign Key ที่ไม่มีจริง หรือการเพิ่มวัตถุดิบซ้ำในสูตรเดิม
* **มาตรฐานการตอบกลับ HTTP (Standardized HTTP Responses):** ตอบกลับด้วย Status Codes ตามมาตรฐานสากล เช่น `200 OK`, `204 NoContent`, `400 BadRequest` และ `404 NotFound`
* **รองรับการเชื่อมต่อข้ามโดเมน (CORS Configured):** ติดตั้ง Cross-Origin Resource Sharing สำหรับการดึงข้อมูลจาก Frontend สมัยใหม่ (React, Vue, Flutter, MAUI)
* **เอกสาร API แบบโต้ตอบ (Interactive Documentation):** มีหน้า Swagger UI (OpenAPI 3.0) พร้อมแสดง Schemas สำหรับทดสอบ Request/Response ได้ทันที

---

## สถาปัตยกรรมและเทคโนโลยีที่ใช้ (Architecture & Tech Stack)

* **ภาษาที่ใช้พัฒนา:** C# (.NET)
* **เฟรมเวิร์ก:** ASP.NET Core Web API
* **การจัดการฐานข้อมูล (ORM):** Entity Framework Core
* **ระบบฐานข้อมูล:** Microsoft SQL Server
* **รูปแบบสถาปัตยกรรม (Architecture Pattern):** Layered Architecture (Controller ↔ Service Layer ↔ DbContext / Repository)
* **การส่งผ่านข้อมูล:** Data Transfer Objects (DTOs)
* **เอกสาร API:** Swagger / OpenAPI

---

## โครงสร้างฐานข้อมูล (Database Schema)

* `Menus`: บันทึกข้อมูลเมนูอาหาร ราคาต้นทุนรวมที่คำนวณได้ (`TotalPrice`) และประวัติการอัปเดต
* `Materials`: บันทึกข้อมูลวัตถุดิบ หน่วยนับ และราคาต้นทุนต่อหน่วย
* `MenuMaterials`: ตารางเชื่อมโยง Many-to-Many โดยใช้ Composite Key (`MenuId` + `MaterialId`) จัดเก็บปริมาณวัตถุดิบที่ใช้เฉพาะในแต่ละเมนู

---

## โครงสร้างโปรเจกต์ (Project Structure)

```text
MENUAPI/
├── MENUAPI/
│   ├── Controllers/       # API Endpoints (Menu, Material, MenuMaterial)
│   ├── DTOs/              # Request / Response Data Transfer Objects
│   ├── Models/            # Database Entities
│   ├── Services/          # Core Business Logic & Price Calculation Engine
│   ├── Data/              # ApplicationDbContext & Entity Configurations
│   └── Program.cs         # Dependency Injection, Middleware & Service Configurations
├── .gitattributes
├── .gitignore
└── MENUAPI.slnx           # Visual Studio Solution File

วิธีการติดตั้งและรันโปรเจกต์ (Getting Started)
ข้อกำหนดเบื้องต้น (Prerequisites)
1) ระบบปฏิบัติการ Windows, macOS หรือ Linux
2) .NET SDK (เวอร์ชันเดียวกับที่สร้างโปรเจกต์)
3) Microsoft SQL Server หรือ SQL Server Express / LocalDB
4) Visual Studio 2022 หรือ Visual Studio Code

ขั้นตอนการรันจาก Source Code
1) Clone รีโปซิโทรีลงบนเครื่อง: git clone [https://github.com/rtsom/MenuApi-Practice-ASP.NET-SWAGGER-Doc.git](https://github.com/rtsom/MenuApi-Practice-ASP.NET-SWAGGER-Doc.git)
2) กำหนดค่าการเชื่อมต่อฐานข้อมูลในไฟล์ appsettings.json: "ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=MenuDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
3) สั่ง Update Database ผ่าน Package Manager Console หรือ .NET CLI: dotnet ef database update
4) สั่งรันโปรเจกต์: dotnet run
5) เข้าใช้งานหน้าทดสอบ API ได้ที่: https://localhost:7000/swagger

ผู้พัฒนา (Author)
พัฒนาโดย rtsomixdev
