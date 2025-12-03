* Format validation
* Domain availability
* DNS lookup
* MX record check
* Allowed/Blocked domain rules
* Custom EmailBlockerLib for dummy blocking

It also includes a submission form, dashboard, and blocked email list.

---

## ** Update (New)**

### **✔ Added Advanced Email Validation**

* DNS lookup for domain
* MX record verification
* Regex-based format validation

### **✔ Integrated DummyEmailChecker (EmailBlockerLib)**

* Checks blocked emails
* Checks blocked domains
* Allows only safe domains
* Uses live DNS to validate unknown domains

### **✔ Added NuGet Package Support**

Installed:

```
DnsClient
Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
```

Updated logic in:

* `AdvancedEmailValidator.cs`
* `ContactController.cs`
* `DummyEmailChecker.cs`

### **✔ Added Domain Dictionary Logic**

If email domain exists in **BlockedDomains**, return error:

```
Not a valid email address.
```

If not blocked → validate using DNS + MX.

---

## **Features**

* ✔ **Email Validation** (Regex + DNS + MX + Allowed/Blocked rules)
* ✔ **Contact Form Submission**
* ✔ **Blocked Email Handling**
* ✔ **Dashboard with statistics**
* ✔ **Bootstrap Alerts for messages**
* ✔ **Custom EmailBlockerLib integration**

---

## **Prerequisites**

* .NET 8 SDK
* NuGet Packages:

  ```
  DnsClient
  Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
  ```

---

## **Setup Instructions**

### **1. Restore Dependencies**

```
dotnet restore
```

### **2. Build**

```
dotnet build
```

### **3. Run**

```
dotnet run
```

App will start on something like:

```
http://localhost:/
```

---

## **App URLs**

| Feature        | URL                     |
| -------------- | ----------------------- |
| Home           | `/`                     |
| Contact Form   | `/Contact/Index`        |
| Dashboard      | `/Contact/Dashboard`    |
| Blocked Emails | `/Contact/BlockedEmail` |

---

## **Project Structure**

### **Controllers**

* `ContactController.cs` → Form submission + advanced email rules

### **Services**

* `AdvancedEmailValidator.cs` → Format + DNS + MX check
* `EmailBlockService.cs` → Wrapper for DummyEmailChecker
* `EmailBlockerLib` → Blocked emails/domains/patterns

### **Views**

* Razor UI pages

### **wwwroot**

* Bootstrap
* Custom CSS
* Alert JS

---

## **Key Files Updated Today**

* `DummyEmailChecker.cs`
* `AdvancedEmailValidator.cs`
* `ContactController.cs`
* README.md (this file)

---

## **NuGet Packages Used**

```
DnsClient
Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
```

---

## **Frontend Tools**

* Bootstrap 5
* jQuery Validation
* Custom JS for messages

---




