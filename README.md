# ✈️ Jasmin Travels – ASP.NET Core MVC Travel Agency System  

---

## 📌 Important Note
The **owner of Jasmin Travels has chosen NOT to display or distribute the source code publicly**.  
This repository provides a **project overview, documentation, and architecture details only**.  

---

## 📖 Overview
**Jasmin Travels** is a **full-stack ASP.NET Core 6 MVC travel agency application**.  
It combines a **public-facing travel website** with an **administrative dashboard** to manage all aspects of the business.  

Key features include:  
- User authentication & account management  
- Travel packages with images, itineraries, and PDF uploads  
- Online reservations with **Stripe checkout**  
- Ratings & comments for packages  
- Contact forms with admin management  
- Admin dash with roles, users, packages, reservations, and content management   
- Email notifications & file handling  

---

## 🚀 Features

### 👤 Authentication & Accounts
- sign up, Sign in, logout  
- Forget/Reset password with email verification  
- Role-based access (User/Admin)  

### 🧳 Travel Packages
- Admin CRUD (create, edit, delete, details)  
- Multiple images + PDF program upload  
- Day-by-day itineraries & descriptions  
- Ratings and comments  

### 📅 Reservations
- Dynamic pricing (hotel type, travelers, children)  
- Collects passport info, nationality, gender, contact details  
- Stripe checkout for secure payment  
- Admin CRUD for reservations  

### ⭐ Ratings & Comments
- Users can rate packages  
- Add comments with moderation tools  
- Ratings linked to IP for tracking  

### 📩 Contact Us
- Public contact form (name, email, subject, message)  
- Admin panel for managing submissions  

### 📊 Admin Dash
- Manage **Packages, Reservations, Comments, Ratings, Contact Us, Users, Roles**  
- Dashboard cards with latest updates  

### ✉️ Email Notifications
- Password reset emails via Gmail SMTP  
- Contact confirmations  

---

## 🛠️ Tech Stack
- **ASP.NET Core 6 MVC**  
- **Entity Framework Core 6**  
- **ASP.NET Identity**  
- **AutoMapper**  
- **Stripe Checkout**  
- **SQL Server**  
- **Bootstrap / Razor Views**  

---

## 📂 Architecture

### **Models**
- ApplicationUser  
- Packages  
- Reservations  
- PackageComments  
- PackageRating  
- ContactUs  

### **Repositories & Interfaces**
- GenericRepository / IGenericRepository  
- PkgRepo / IPkgRepo
- ResRepo / IReRepo
- RatingRepo / IRatingRepo  
- CommentsRepository / ICommentsRep  
- ContactRepo / IContactRepo  

### **Specifications**
- Pkg with Ratings & Comments  
- Res with Pkg  
- Comments with Pkg  
- Ratings with Pkg  

### **AutoMapper Profiles**
- PkgsProfile  
- ResProfile  
- PkgCommentsProfile  
- PkgRatingProfile  
- ContactProfile  
- RoleProfile  
- UserProfile  

### **Controllers**
- AccController  
- HomeController  
- PkgController  
- ResController  
- CmmentsController  
- RatController  
- ContactController  
- jasmincrController  
- RoleController  
- UserController  
- languageController  

### **Views**
- Auth → Signin, logup, ForgetPassword, ResetPassword  
- Public → Index, AboutUs, Pkg, PkgDetails, ContactUs, Res, Terms, Policy, PaymentAndRefund  
- Admin → Pkg (CRUD), Res (CRUD), Cmments, Ratings, Contact, Us (CRUD), Roles (CRUD)  
- Layouts → _Layout, _AuthLayout, DashLayout, Shared partials  

---

## ⚙️ Setup (for internal use only)

> ⚠️ Note: Since **source code is private**, setup instructions are **not included publicly**.  
> The system runs on **ASP.NET Core 6 MVC + EF Core + SQL Server**, with Stripe integration and SMTP email.  

---

## 🌟 Future Enhancements
- AI-based travel recommendations  
- Mobile app frontend (Flutter/React Native)  
- CI/CD deployment pipeline  
- Multi-currency payment support  

---

