# TechM-Assignment

📌 Project Overview

This repository contains both:

    ✅ Manual Test Design Document

    ✅ Automated UI Test Solution (Selenium + NUnit)

The assignment validates checkout behavior on the OpenCart demo site.

Application Under Test: https://demo.opencart.com


Technology Stack:

    Language: C# (.NET 6) or above
    UI Automation: Selenium WebDriver
    Test Framework: NUnit
    Assertion Library: Default Assertions
    Version Control: Git

🎯 Objective

Validate system behavior when:

    User adds two products (iMac and iPhone) to cart
    Navigates to Shopping Cart
    Proceeds to Checkout
    System blocks checkout due to stock unavailability
    Warning message is displayed
    Products are marked with "***"
    

🧾 Manual Test Coverage

  The TestDesign.docx document includes:
  
    Test scenarios
    Step-by-step actions
    Expected results
    

🤖 Automation Scope

  The automated test validates:

    Product addition to cart
    Cart content verification
    Checkout navigation
    Warning message validation:


⚠️ Environment Limitation – Cloudflare Protection

The OpenCart demo site is protected by Cloudflare security verification. When Selenium WebDriver launches Chrome, the site detects automated traffic and displays a security verification page.

As a result:

    Automation cannot consistently navigate to the actual application.
    This is not a functional failure of the test.
    This is an environmental security restriction.

The automation code reflects the intended flow but execution may be blocked due to this external constraint.


🚀 How to Run the Automation Code

    1. Open Visual Studio
    2. Create a new NUnit Test Project (.NET 6)
    3. Install required NuGet packages:
    4. Selenium.WebDriver
    5. Selenium.Support
    6. Copy repository class files into the project
    7. Build the solution (Ctrl + Shift + B)
    8. Open cmd and navigate to path where dll is preset
    9. run command 
        "dotnet test Project.dll"
    10. Replace Project.dll with the actual project name you created.
        For example, if your project name is TechM.Assignment, then run:
          "dotnet test TechM.Assignment.dll"
