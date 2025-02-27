
# 🧾 InvoiceRegister

**InvoiceRegister** is a tool designed for polish companies to register and generate invoices.

---

## 🚀 Technologies

![.NET WPF](https://img.shields.io/badge/.NET%20WPF-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![XAML](https://img.shields.io/badge/XAML-0C54C2?style=for-the-badge&logo=.net&logoColor=white)
![MSSQL](https://img.shields.io/badge/MSSQL-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![SendGrid](https://img.shields.io/badge/SendGrid-008CE7?style=for-the-badge&logo=sendgrid&logoColor=white)

---

## 📦 **Preview**
![image](https://github.com/user-attachments/assets/be0085af-8476-4ec0-b623-457d7ec50439)

---

## 📋 Features

### **Creating Invoices**
![image](https://github.com/user-attachments/assets/c0b4c6ff-17ff-49ab-a8a7-209c478868df)

### **Filtering Results**
![image](https://github.com/user-attachments/assets/c25bc538-6715-4491-91e8-5e797b121193)

### **Adding Items to Invoice**
![image](https://github.com/user-attachments/assets/1f2cd372-8197-44ab-9b61-c49944d6ccf9)

### **Generating PDF**
![image](https://github.com/user-attachments/assets/9f15260d-061a-4ee9-9b39-ad6f978b5fd5)

---

## 💡 How to Run the Project Locally?

1. Clone the repository:  
   ```bash
   git clone https://github.com/your-username/EliteAthleteApp.git
   ```
2. Create appsettings.json file inside of the main folder
3. Add this structure to appsettings.json and fill the fields in square brackets:
   ```json
   {
     "ConnectionStrings": {
    "DatabaseConnectionString": "Server=[YOUR SERVER NAME];Database=[YOUR DATABASE NAME];Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False",
    "SendGridConnectionString": "[SEND GRID ID]"
     },
     "Email": "[YOUR EMAIL FOR EMAIL SENDER]",
     "AllowedHosts": "*"
     }
   ```
4. Run database migrations using Entity Framework:  
   ```bash
   dotnet ef database update
   ```
5. Start the application:  
   ```bash
   dotnet run
   ```
