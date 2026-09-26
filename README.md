# 🔐 Project Password Generator

> A simple desktop utility built with C# and Windows Forms for generating random passwords and GUIDs through a clean and straightforward interface.

---

<img width="870" height="776" alt="image" src="https://github.com/user-attachments/assets/2749a9e9-67a2-44f1-8c1a-3aa0bc53a211" />


---

## 🚀 Project Overview

**Project 27** is a C# Windows Forms practice project focused on building a simple password generation tool.

The application allows the user to generate either a **random password** or a **GUID** from the same interface.

For passwords, the user can choose the character types to include and control the password length.

The project focuses on practicing Windows Forms controls, event handling, random character generation, and organizing application logic into reusable methods.

---

## ⚙️ Core Functionalities

| Feature | Description |
|---|---|
| 🔒 **Password Generator** | Generates a random password based on the selected character types |
| 🆔 **GUID Generator** | Generates a new .NET GUID |
| 🔠 **Uppercase Letters** | Includes uppercase letters in the generated password |
| 🔡 **Lowercase Letters** | Includes lowercase letters in the generated password |
| 🔢 **Numbers** | Includes numbers in the generated password |
| 🔣 **Symbols** | Includes symbols in the generated password |
| 🔢 **Password Length** | Controls the number of characters generated |
| 📊 **Progress Bar** | Shows the selected password character types |
| 📋 **Copy** | Copies the generated password or GUID |
| 🗑️ **Clear** | Clears the generated output and resets the progress bar |

---

## 🏗️ Application Flow

```text
Form1_Load
 └── Set Password mode as default

btnGenerate_Click
 ├── Validate character type selection
 │
 ├── Password
 │    └── GeneratePassword()
 │         └── GenerateWord()
 │              └── GetRandomChar()
 │                   ├── Uppercase
 │                   ├── Lowercase
 │                   ├── Numbers
 │                   └── Symbols
 │
 └── GUID
      └── GenerateGUID()
           └── Guid.NewGuid()

IcreaseProgressBar()
 ├── GUID → 100%
 └── Password
      ├── Uppercase → +25%
      ├── Lowercase → +25%
      ├── Numbers → +25%
      └── Symbols → +25%

btnCopy_Click
 └── SelectAll() → Copy()

btnClear_Click
 └── Clear Output → Reset ProgressBar
```

---

## 🧠 Design Decisions Worth Noting

### Reusable Character Generation

Instead of generating each character directly inside the password generation loop, the project separates the process into reusable methods:

```csharp
private char GetRandomChar()
{
    StringBuilder Pool = new StringBuilder();

    if (chkUppercase.Checked) Pool.Append(GetRandomUpperCaseLttr());
    if (chkLowercase.Checked) Pool.Append(GetRandomLowerCaseLttr());
    if (chkNumber.Checked) Pool.Append(GetRandomNumbers());
    if (chkSymbols.Checked) Pool.Append(GetRandomSymbols());

    return Pool[RandomNumber.Next(Pool.Length)];
}
```

The selected character types are added to a single character pool, and a random character is then selected from that pool.

---

### Password Length Control

The password length is controlled using a `NumericUpDown` control:

```csharp
for (int i = 0; i < numericUpDown1.Value; i++)
{
    Password += GetRandomChar();
}
```

This allows the user to determine how many characters should be generated.

---

### Password Strength Indicator

The ProgressBar represents the variety of character types selected by the user.

Each selected type contributes **25%**:

```text
Uppercase → +25%
Lowercase → +25%
Numbers   → +25%
Symbols   → +25%
```

Selecting all four character types results in **100%**.

When GUID mode is selected, the ProgressBar is set to **100%**.

---

### GUID Generation

The project also provides a simple GUID generator using the built-in .NET `Guid` class:

```csharp
private string GenerateGUID()
{
    return Guid.NewGuid().ToString();
}
```

This generates a new GUID whenever the user selects GUID mode and presses Generate.

---

## 🛠️ Tech Stack

| | |
|---|---|
| **Language** | C# |
| **Framework** | .NET Framework |
| **UI** | Windows Forms (WinForms) |
| **IDE** | Visual Studio |
| **Type** | Desktop Application |
| **Controls Used** | Form, Label, TextBox, Button, CheckBox, RadioButton, NumericUpDown, ProgressBar |

---

## 📚 What I Practiced

Through this project, I practiced:

- C# methods
- Random number generation
- Character generation
- `StringBuilder`
- `Guid.NewGuid()`
- Windows Forms controls
- CheckBox handling
- RadioButton handling
- NumericUpDown
- ProgressBar
- Clipboard operations
- Input validation
- Event handling
- Breaking functionality into reusable methods

---

