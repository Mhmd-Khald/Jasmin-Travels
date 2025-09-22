# ✈️ Jasmin Travels – ASP.NET Core MVC Travel Agency System  

![Jasmin Travels](https://via.placeholder.com/900x200.png?text=Jasmin+Travels+System)  

[![Build Status](https://img.shields.io/badge/build-passing-brightgreen)]()  
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)  
[![Localization](https://img.shields.io/badge/EN-AR-blue)]()  
[![Payments](https://img.shields.io/badge/Stripe-Integrated-purple)]()  

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
- Admin dashboard with roles, users, packages, reservations, and content management  
- Localization (English & Arabic)  
- Email notifications & file handling  

---

## 🚀 Features

### 👤 Authentication & Accounts
- Register, login, logout  
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

### 📊 Admin Dashboard
- Manage **Packages, Reservations, Comments, Ratings, ContactUs, Users, Roles**  
- Dashboard cards with latest updates  

### 🌐 Localization
- English / Arabic support  
- Language switcher in UI  

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
- **Localization (EN/AR)**  
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

### **ViewModels**
- Auth → Login, Register, ForgetPassword, ResetPassword  
- Packages → PackagesViewModel, PackageRatingViewModel, CommentsViewModel  
- Reservations → ReservationsViewModel  
- Contacts → ContactUsViewModel  
- Admin → RoleViewModel, UserViewModel, AllModels  

### **Repositories & Interfaces**
- GenericRepository / IGenericRepository  
- PackageRepository / IPackageRepository  
- ReservationRepository / IReservationRepository  
- RatingRepository / IRatingRepository  
- CommentsRepository / ICommentsRepository  
- ContactUsRepository / IContactUsRepository  

### **Specifications**
- Package with Ratings & Comments  
- Reservations with Packages  
- Comments with Packages  
- Ratings with Packages  

### **AutoMapper Profiles**
- PackagesProfile  
- ReservationsProfile  
- PackageCommentsProfile  
- PackageRatingProfile  
- ContactUsProfile  
- RoleProfile  
- UserProfile  

### **Controllers**
- AccountController  
- HomeController  
- PackageController  
- ReservationController  
- CommentsController  
- RatingController  
- ContactUsController  
- jasminDashBoardController  
- RoleController  
- UserController  
- languageController  

### **Views**
- Auth → Login, Register, ForgetPassword, ResetPassword  
- Public → Index, AboutUs, Packages, PackageDetails, ContactUs, Reservation, Terms, Policy, PaymentAndRefund  
- Admin → Packages (CRUD), Reservations (CRUD), Comments, Ratings, ContactUs, Users (CRUD), Roles (CRUD)  
- Layouts → _Layout, _AuthLayout, DashBoardLayout, Shared partials  

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

## 📄 License
This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file.  
