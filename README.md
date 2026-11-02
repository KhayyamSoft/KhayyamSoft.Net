# 🧰 KhayyamSoft.Net – .NET Utility Libraries

A **monorepo of three reusable .NET class libraries** by KhayyamSoft:

| Package | Namespace | Version | What it gives you |
|---------|-----------|---------|-------------------|
| **`KhayyamApps.DateAndTime`** | `KhayyamApps.DateAndTime` | `0.1` | Persian (Jalali) calendar helpers, time-as-integer, Unix timestamps |
| **`KhayyamApps.Security`** | `KhayyamApps.Security` | `0.2.1` | AES & RSA encryption, BouncyCastle AES, SHA-256/512 hashing, password/key generation, array utilities |
| **`KhayyamApps.Windows`** | `KhayyamApps.Windows` | `0.4.4` | WPF extensions: draggable windows, Enter-key focus movement, file dialogs, value converters, splash/main-window startup |

All three are **class libraries** (no runnable app in the repository), target **`netcoreapp3.1`**, and are consumed as NuGet packages or project references.

> **Repository description:** *“KhayyamSoft.Net”* (the original `README.md` contains only this one line).

---

## 📖 Overview

`KhayyamSoft.Net` collects small, focused utilities that were needed across KhayyamSoft’s desktop and web projects and extracted into reusable packages.

- **`DateAndTime`** solves the “I need a Jalali date, a `HHmm` integer, or a Unix timestamp” problems that recur in Iranian-market applications.
- **`Security`** wraps the .NET cryptography APIs (and BouncyCastle) behind simple static methods, and includes a test project.
- **`Windows`** removes the boilerplate of WPF windows: dragging a borderless window, moving focus with **Enter**, showing splash screens, and converting booleans/ints/strings to `Visibility`, `Cursor`, `ImageSource`, and `Color`.

Each package is independent — you can reference only the one you need.

---

## 🗂️ Repository Structure

```text
KhayyamSoft.Net/
├── packages/
│   ├── date-and-time/
│   │   ├── KhayyamApps.DateAndTime.csproj   # netcoreapp3.1, v0.1
│   │   ├── KhayyamApps.DateAndTime.sln
│   │   ├── PersianDate.cs                   # Jalali calendar + month names
│   │   ├── Time.cs                          # DateTime → HHmm int
│   │   └── UnixTime.cs                      # Unix timestamp ⇄ DateTime
│   ├── security/
│   │   ├── KhayyamApps.Security.csproj      # netcoreapp3.1, v0.2.1
│   │   ├── BC/                              # BouncyCastle-based crypto
│   │   │   ├── AES.cs
│   │   │   ├── BCBase.cs
│   │   │   └── DataHelper.cs
│   │   ├── Crypto/                          # .NET built-in crypto
│   │   │   ├── AES.cs
│   │   │   └── RSA.cs
│   │   ├── Hash/
│   │   │   └── Hash.cs                      # SHA-256 / SHA-512
│   │   ├── KeyGenerator/
│   │   │   └── KeyGenerator.cs              # passwords & random keys
│   │   ├── Utilities/
│   │   │   └── Utilities.cs                 # Fisher–Yates shuffle
│   │   ├── SecurityTest/                    # test project
│   │   │   ├── AESTest.cs
│   │   │   ├── HashTest.cs
│   │   │   ├── KeyGeneratorTest.cs
│   │   │   ├── RSATest.cs
│   │   │   └── SecurityTest.csproj
│   │   ├── BouncyCastle.Crypto.dll          # bundled dependency
│   │   └── LICENSE
│   └── windows/
│       ├── KhayyamApps.Windows.csproj       # netcoreapp3.1, v0.4.4
│       ├── ApplicationExtensions/           # ApplicationInfo, Resources, Startup
│       ├── DataConverters/                  # Bool/Int/String → WPF types
│       ├── FrameworkElementExtensions/      # focus helpers
│       ├── ObjectExtensions/                # collection/control/binary equality
│       ├── ThreadExtensions/                # culture helpers
│       ├── UIElementExtensions/             # keyboard focus movement
│       ├── Win32Dialogs/                    # OpenFileDialog / SaveFileDialog
│       ├── WindowExtensions/                # drag, input, state, dialog
│       └── WindowX/                         # CustomWindow1
├── .gitignore
└── README.md
```

## 📦 Package 1 – `KhayyamApps.DateAndTime` (v0.1)

**Target:** `netcoreapp3.1`  
**Source:** three static classes in `packages/date-and-time/`

### What it does

#### `PersianDate` – Jalali calendar helpers

Uses `System.Globalization.PersianCalendar` to convert a `DateTime` to the Persian calendar.

|Member|Returns|Example|
|---|---|---|
|`PersianMonthNames`|`string[]` of the 12 Persian months (فروردین … اسفند)|`PersianDate.PersianMonthNames[0]` → `"فروردین"`|
|`GetMonthName(int month)`|Persian month name; **throws** `ArgumentOutOfRangeException` for month ∉ [1,12]|`GetMonthName(1)` → `"فروردین"`|
|`SafeGetMonthName(int month)`|Same as above, but returns `""` instead of throwing|`SafeGetMonthName(13)` → `""`|
|`GetPersianYear(this DateTime)`|`int` Jalali year|`date.GetPersianYear()`|
|`GetPersianMonth(this DateTime)`|`int` Jalali month (1–12)|`date.GetPersianMonth()`|
|`GetPersianDay(this DateTime)`|`int` Jalali day of month|`date.GetPersianDay()`|
|`GetPersianDateInInt(this DateTime)`|`int` `YYYYMMDD`, e.g. `14001231`|`date.GetPersianDateInInt()`|
|`GetPersianDateInString(this DateTime)`|`string` `YYYY/MM/DD`, e.g. `"1400/12/31"`|`date.GetPersianDateInString()`|

```csharp
using KhayyamApps.DateAndTime;
DateTime now = DateTime.Now;
Console.WriteLine(now.GetPersianDateInString()); // e.g. 1403/08/13
Console.WriteLine(PersianDate.GetMonthName(now.GetPersianMonth())); // e.g. آبان
Console.WriteLine(now.GetPersianDateInInt()); // e.g. 14030813
```

#### `Time` – time as an integer

|Member|Returns|Example|
|---|---|---|
|`GetTimeInInt(this DateTime)`|`int` `HHmm` (e.g. `1731` for 17:31)|`date.GetTimeInInt()`|

#### `UnixTime` – Unix timestamps

|Member|Returns|
|---|---|
|`GetUnixTimeStamp()`|`long` seconds since 1970-01-01 00:00 **local** (via `DateTimeOffset.Now.ToUnixTimeSeconds()`)|
|`UnixTimestampToLocalDateTime(double timestamp)`|`DateTime` in **local** time|

```csharp
long ts = UnixTime.GetUnixTimeStamp();
DateTime dt = UnixTime.UnixTimestampToLocalDateTime(ts);
```

---
## 📦 Package 2 – `KhayyamApps.Security` (v0.2.1)

**Target:** `netcoreapp3.1`  
**Dependency:** bundled `BouncyCastle.Crypto.dll`  
**Tests:** `SecurityTest/` project

### Crypto (`KhayyamApps.Security.Crypto`)

#### `AES` – .NET built-in AES

|Method|Description|
|---|---|
|`byte[] Encrypt(string plainText, byte[] key, byte[] iv)`|Encrypt with a caller-supplied key and IV|
|`byte[] Encrypt(string plainText, out byte[] key, out byte[] iv)`|Encrypt and **generate** a random key/IV|
|`string Decrypt(byte[] encryptedText, byte[] key, byte[] iv)`|Decrypt back to a UTF-8 string|

```csharp
using KhayyamApps.Security.Crypto;
byte[] cipher = AES.Encrypt("secret", out byte[] key, out byte[] iv);
string plain = AES.Decrypt(cipher, key, iv);
```
#### `RSA` – asymmetric encryption

|Method|Description|
|---|---|
|`byte[] RSAEncrypt(string input, RSAParameters rsaKeyInfo, bool doOAEPPadding = false)`|Encrypt with the **public** parameters (`ExportParameters(false)`)|
|`byte[] RSADecrypt(string input, RSAParameters rsaKeyInfo, bool doOAEPPadding = false)`|Decrypt with the **private** parameters (`ExportParameters(true)`)|

> ⚠️ `RSADecrypt` accepts a `string` and converts it with `UnicodeEncoding` — it is intended to be used with a Base64 string of the encrypted bytes, not the raw byte array. Verify the exact contract in `RSA.cs` before relying on it.

### BouncyCastle crypto (`KhayyamApps.Security.BC`)

|Type|Description|
|---|---|
|`BCBase.Encrypt(byte[] plain, ReadOnlySpan<char> keyByte, IBlockCipher blockCipher)`|Generic padded block-cipher encryption|
|`BCBase.Decrypt(string cipher, ReadOnlySpan<char> keyByte, IBlockCipher blockCipher)`|Decrypt a **Base64** string|
|`BC.AES.Encrypt(string plain, ReadOnlySpan<char> key)`|AES via BouncyCastle; returns **Base64**|
|`BC.AES.Decrypt(string cipher, ReadOnlySpan<char> key)`|AES via BouncyCastle; returns UTF-8 string|

```csharp
using KhayyamApps.Security.BC;
string cipher = AES.Encrypt("secret", "my-key");
string plain  = AES.Decrypt(cipher, "my-key");
```

### Hashing (`KhayyamApps.Security.Hash`)

|Method|Output|
|---|---|
|`Hash.GetSHA256Hash(string input)`|Base64 string|
|`Hash.GetSHA512Hash(string input)`|Base64 string|

### Key generation (`KhayyamApps.Security.KeyGenerator`)

|Method|Description|
|---|---|
|`string GeneratePassword(int length, bool containAmbiguous = true)`|Random password mixing upper/lower/digits/symbols (and optionally ambiguous chars), then shuffled|
|`byte[] GenerateKey(int length)`|Random byte array|

> The password generator draws from `ABCDEFGHIJKLMNOPQRSTUVWXYZ`, `abcdefghijklmnopqrstuvwxyz`, `1234567890`, `!@#$%^&*-_=+-`, and (optionally) `{}[]()/'"`~,;:.<>`. It uses`new Random((int)DateTime.Now.Ticks)` — **not** a cryptographically secure RNG.

### Utilities (`KhayyamApps.Security.Utilities`)

|Method|Description|
|---|---|
|`T[] Arrays.ShuffleArray<T>(T[] input)`|Fisher–Yates shuffle (in place)|
|`string Arrays.ShuffleString(string input)`|Shuffle characters with the same algorithm|

---

## 📦 Package 3 – `KhayyamApps.Windows` (v0.4.4)

**Target:** `netcoreapp3.1` (WPF)  
**Source:** `packages/windows/`

### Application startup (`ApplicationExtensions`)

|Type / Method|Description|
|---|---|
|`ApplicationInfo`|Holds `AppVersion`, `AppCulture` (default invariant), and localized app names via `SetAppName(language, name)` / `GetAppName(language)`|
|`ApplicationResources`|Application resource helpers|
|`ApplicationStartup.ShowSplashScreen(this Application app, Window splash)`|Sets `splash` as `MainWindow` and shows it|
|`ApplicationStartup.ShowMainWindow(this Application app, Window mainWindow, Window splashWindow = null)`|Sets `mainWindow` as `MainWindow`, shows it, closes the splash, then activates|

```csharp
protected override void OnStartup(StartupEventArgs e)
{
    base.OnStartup(e);
    var splash = new SplashWindow();
    this.ShowSplashScreen(splash);
    var main = new MainWindow();
    this.ShowMainWindow(main, splash);
}
```

### Window behaviour (`WindowExtensions`)

|Method|Description|
|---|---|
|`DragWindowWithMouse(this Window window, MouseButtonEventArgs e, bool restrictMaximizeDrag = true)`|Drag a borderless window while the left button is held; optionally skip when maximized|
|`MakeWindowDraggableWithMouse(this Window window, bool restrictMaximizeDrag = true)`|Subscribes `MouseDown` to the drag behaviour|
|`WindowAsDialogExtensions`|Helpers to show a `Window` as a dialog|
|`WindowHelpers`|Miscellaneous window helpers|
|`WindowStateControl`|Window-state controls|

### Keyboard navigation & focus

|Type|Description|
|---|---|
|`UIElementFocusExtensions.MoveUIElementFocusWithKeyboard(...)`|Move focus to the next/previous element with a key (used by `CustomWindow1` with **Enter**)|
|`FrameworkElementFocusExtensions`|Focus helpers for `FrameworkElement`|
|`ThreadCultureExtensions`|Culture helpers for the current thread|

### `WindowX.CustomWindow1`

A `Window` subclass that:

- Can be dragged with the mouse (`MakeWindowDraggableWithMouse`)
    
- Moves focus to the next UI element on **Enter**
    
- Can be closed with **Enter** when `IsDialog = true`
    
- Exposes `EnterFocusMoveResterictedControls` (a collection of controls where Enter should **not** move focus, e.g. multiline text boxes)
    

csharp

var dialog = new CustomWindow1 { IsDialog = true };
dialog.EnterFocusMoveResterictedControls.Add(myTextBox);
dialog.ShowDialog();

### Win32 dialogs (`Win32Dialogs`)

|Method|Description|
|---|---|
|`OpenFileDialogHelper.NewOpenFileDialog(bool fileAndPathCheck = true, bool multiSelect = false, string defaultExt = null, string filter = null)`|Configured `Microsoft.Win32.OpenFileDialog`|
|`OpenFileDialogHelper.ShowSimpleFileDialog()`|Show a simple open dialog; returns the selected path or `null`|
|`SaveFileDialogHelper`|Equivalent helpers for `SaveFileDialog`|

### Value converters (`DataConverters`)

|Converter|Converts|
|---|---|
|`Bool2VisibilityConverter`|`bool` → `Visibility`|
|`Bool2CursorConverter`|`bool` → `Cursor`|
|`String2CursorConverter`|`string` → `Cursor`|
|`String2ImageSourceConverter`|`string` (path/URI) → `ImageSource`|
|`StringImageSource2BoolConverter`|`string`/`ImageSource` → `bool`|
|`IntColorConverter`|`int` → `Color`|
|`IntAlphaColorConverter`|`int` → `Color` with alpha|
|`StaticImageSourceConverter`|Static `ImageSource` provider|

### Object, collection & binary helpers (`ObjectExtensions`)

|Type|Description|
|---|---|
|`CollectionObjectsDataExtensions`|Helpers for collections of objects|
|`ControlObjectDataExtensions`|Helpers for WPF controls|
|`ObjectBinaryEqualityExtensions`|Binary equality comparison for objects|

---
## 🛠️ Technologies

|Item|Details|
|---|---|
|**Language**|C#|
|**Target framework**|**`netcoreapp3.1`** (all three packages)|
|**UI framework**|WPF (only `KhayyamApps.Windows`)|
|**Crypto**|`System.Security.Cryptography` (AES, RSA, SHA-256, SHA-512) + **BouncyCastle** (`BouncyCastle.Crypto.dll`)|
|**Calendar**|`System.Globalization.PersianCalendar`|
|**Packaging**|NuGet-style `.csproj` per package (no root solution)|
|**Tests**|`SecurityTest` project (AES, Hash, KeyGenerator, RSA)|

---
## 🚀 Getting Started

### Prerequisites

- **.NET Core 3.1 SDK** (the packages target `netcoreapp3.1`).
    
    > ⚠️ .NET Core 3.1 is **out of support**. To use these libraries on a modern runtime, retarget the `.csproj` files (e.g. `net8.0` / `net8.0-windows`) and re-verify the BouncyCastle and WPF references.
    
- **Visual Studio 2019/2022** (for the WPF package, use the **.NET desktop development** workload).
    

### Build a package

Each package is self-contained. For example:

```bash
git clone https://github.com/KhayyamSoft/KhayyamSoft.Net.git
cd KhayyamSoft.Net/packages/security
dotnet build KhayyamApps.Security.csproj
```

```bash
cd ../date-and-time
dotnet build KhayyamApps.DateAndTime.csproj
cd ../windows
dotnet build KhayyamApps.Windows.csproj
```

### Run the security tests

```bash
cd packages/security/SecurityTest
dotnet test
```


> The `windows` and `date-and-time` packages have **no test project** in the repository.

### Reference from your project

**Project reference:**

```xml
<ItemGroup>
  <ProjectReference Include="..\KhayyamSoft.Net\packages\date-and-time\KhayyamApps.DateAndTime.csproj" />
</ItemGroup>
```

**DLL reference** (after building): add the produced `KhayyamApps.*.dll` from `bin/Debug/netcoreapp3.1/`.

---

## 📝 Notes & Caveats

- **.NET Core 3.1 is EOL** — all three `.csproj` files target `netcoreapp3.1`. Expect to retarget before using them in new projects.
    
- **`RSA.RSADecrypt` parameter mismatch** — it takes a `string` and runs it through `UnicodeEncoding.GetBytes`, while `RSAEncrypt` returns `byte[]`. You must Base64-encode the encrypted bytes before passing them to `RSADecrypt`; the method name/type combination is easy to misuse.
    
- **`KeyGenerator` is not cryptographically secure** — both `GeneratePassword` and `GenerateKey` seed `System.Random` from `DateTime.Now.Ticks`. For security-sensitive passwords/keys, use `RandomNumberGenerator`.
    
- **`BC.AES` uses `ReadOnlySpan<char>` keys** — the key is a **char span** (UTF-8 encoded internally by `DataHelper`), not a `byte[]`. The `.NET Crypto.AES` class, by contrast, takes `byte[]` keys. They are not interchangeable.
    
- **`PersianDate.GetMonthName` throws on invalid input** — use `SafeGetMonthName` if the month number comes from untrusted data.
    
- **Windows package has no tests** — the WPF helpers (`CustomWindow1`, drag, converters) are untested in the repository.
    
- **`CustomWindow1` uses reflection-free `UIElement` traversal** — focus movement relies on `MoveUIElementFocusWithKeyboard`; make sure your visual tree is keyboard-navigable.
    
- **No CI/CD or NuGet publishing setup** — the packages are built locally; there are no GitHub Actions or `.nuspec` files in the repository.
    

---
## 🤝 Contributing

Issues and pull requests are welcome — e.g. retargeting to a supported .NET LTS, replacing `System.Random` with `RandomNumberGenerator` in `KeyGenerator`, adding tests for the WPF package, or fixing the `RSADecrypt` signature.

---
## 📄 License

The `packages/security` folder contains a `LICENSE` file; the `date-and-time` and `windows` packages do not. Feel free to use any of them :)
