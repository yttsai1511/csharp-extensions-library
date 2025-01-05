# C# 擴充方法函式庫

一個專為 C# 開發者設計的擴充方法函式庫，內含多種方便的擴充方法，封裝為 DLL 類別庫，適用於各類 .NET 專案，讓您的程式碼更簡潔且易於維護。

## 功能特色

此函式庫包含多個擴充方法，分為以下類別，適用於多種場景的 C# 開發需求：

### 1. `BinaryExtensions`
提供針對二進位資料的操作方法：
- 寫入分段二進位資料：`Write`
- 資料加密與解密（AES）：`ToAES`、`FromAES`
- 資料格式轉換（Base64、Hex、MD5、UTF8）：`ToBase64`、`ToHex`、`ToMD5`、`ToUTF8`

### 2. `CollectionExtensions`
提供集合類型的操作方法：
- 判斷集合是否為空：`IsNullOrEmpty`
- 增加或更新字典的元素：`AddRange`、`Update`、`UpdateRange`
- 遍歷集合並執行操作：`ForEach`
- 提供集合元素的操作（取第一或最後元素、移除、嘗試取得值）：`GetFirst`、`GetLast`、`RemoveFirst`、`RemoveLast`、`TryGetValue`
- 對字典進行累加或條件移除：`Sum`、`RemoveWhere`
- 針對 `HashSet` 和 `List` 提供字串分割並新增元素的功能：`AddRange`

### 3. `DelegateExtensions`
提供委託（Delegate）操作的擴充方法：
- 合併或移除委託：`Combine`、`Remove`
- 註冊或取消註冊委託：`Register`
- 安全執行委託並獲取結果：`TryInvoke`、`GetResults`

### 4. `MathExtensions`
提供數值運算的輔助方法：
- 數值的取整與截斷：`Round`、`Truncate`
- 數值範圍限制與距離計算：`Clamp`、`Distance`
- 數值轉換（整數、浮點數、布林值、列舉）：`ToInt`、`ToFloat`、`ToBoolean`、`ToEnum`
- 判斷數值是否為指定列舉類型：`IsDefined`

### 5. `ReflectionExtensions`
提供基於反射的屬性與欄位操作方法：
- 取得屬性或欄位值：`GetFieldValue`、`GetPropertyValue`
- 設定屬性或欄位值：`SetFieldValue`、`SetPropertyValue`
- 取得類型的指定屬性：`GetAttribute`

### 6. `StringExtensions`
提供針對字串的操作與轉換方法：
- 字串比較與串接：`Compare`、`Concat`
- 格式化與字串分割：`Format`、`TrySplit`
- 字串轉換（Base64、數值、列舉）：`ToBase64`、`ToInt`、`ToEnum`
- 字串修訂（大小寫、移除子字串）：`ToLower`、`ToUpper`、`Remove`
- 判斷字串是否符合條件（空白、字母數字）：`IsNullOrEmpty`、`IsLetterOrDigit`

### 7. `TimeExtensions`
提供時間與日期的輔助操作方法：
- 計算剩餘時間（分鐘或秒）：`GetRemainingMinutes`、`GetRemainingSeconds`
- 計算時間差（分鐘或秒）：`GetDifferenceInMinutes`、`GetDifferenceInSeconds`
- 取得星期的文字表示：`GetWeekString`
- 轉換時間為 Unix 時間戳記：`ToUnixTime`

---

每個功能分類中的函式都設計簡單易用，能有效提升開發效率，適用於各類 .NET 應用程式。更多使用細節請參考以下的範例或完整文件。

## 使用範例

### Binary Extensions

1. `Write`
```csharp
public static void Write(this BinaryWriter writer, byte[] data, int buffer)
```
```csharp
using System.IO;

var data = new byte[1024];
var buffer = 256;

using (var stream = new FileStream("output.bin", FileMode.Create))
using (var writer = new BinaryWriter(stream))
{
    writer.Write(data, buffer); // 將資料分批寫入檔案，每次 256 bytes
}
```

2. `ToAES`
```csharp
public static byte[] ToAES(this byte[] data, string key, string iv)
```
```csharp
var originalData = new byte[] { 1, 2, 3, 4, 5 };
string key = "my-secret-key";
string iv = "my-initialization-vector";

byte[] encryptedData = originalData.ToAES(key, iv); // 將資料加密
```

---

### Collection Extensions

1. `IsNullOrEmpty`
```csharp
public static bool IsNullOrEmpty<TSource>(this ICollection<TSource> collection)
```
```csharp
var collection = new List<int>();
bool isEmpty = collection.IsNullOrEmpty(); // 判斷集合是否為 null 或空
```

2. `TryAdd`
```csharp
public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
```
```csharp
var dictionary = new Dictionary<string, int>();
bool added = dictionary.TryAdd("key1", 100); // 嘗試新增鍵值，若已存在則回傳 false
```

3. `ForEach`
```csharp
public static void ForEach<TSource>(this IEnumerable<TSource> collection, Action<TSource> action)
```
```csharp
var numbers = new[] { 1, 2, 3, 4, 5 };
var results = new List<int>();

numbers.ForEach(num => results.Add(num * 2)); // 將每個數字乘以 2 並加入 results
```

---

### Delegate Extensions

1. `Register`
```csharp
public static TSource Register<TSource>(this TSource source, TSource toRegister, bool isEnable) where TSource : Delegate
```
```csharp
Action<int> action = x => results.Add(x * 2);
Action<int> additionalAction = x => results.Add(x * 3);

action = action.Register(additionalAction, true); // 將 additionalAction 註冊到 action
action(5); // 執行所有註冊的行為
```

2. `GetResults`
```csharp
public static void GetResults<TResult>(this Func<TResult> func, List<TResult> results)
```
```csharp
Func<int> func = () => DateTime.Now.Second;
var results = new List<int>();

func.GetResults(results); // 將每次執行的結果加入 results 清單
```

---

### Math Extensions

1. `Clamp`
```csharp
public static float Clamp(this float value, float min, float max)
```
```csharp
float value = 120f;
float clampedValue = value.Clamp(0f, 100f); // 將數值限制在 0 到 100 之間
```

2. `Distance`
```csharp
public static float Distance(this float source, float destination)
```
```csharp
float point1 = 10.5f;
float point2 = 25.3f;
float distance = point1.Distance(point2); // 計算兩點之間的距離
```

---

### Reflection Extensions

1. `GetFieldValue`
```csharp
public static object GetFieldValue(this object obj, string name)
```
```csharp
class Sample
{
    private int _hiddenField = 42;
}

var sample = new Sample();
object fieldValue = sample.GetFieldValue("_hiddenField"); // 取得私有欄位的值
```

2. `SetPropertyValue`
```csharp
public static void SetPropertyValue(this object obj, string name, object value)
```
```csharp
class Sample
{
    public string Name { get; private set; }
}

var sample = new Sample();
sample.SetPropertyValue("Name", "New Value"); // 設定屬性值為 "New Value"
```

---

### String Extensions

1. `GetName`
```csharp
public static string GetName<TEnum>(this TEnum source) where TEnum : Enum
```
```csharp
enum Colors { Red, Green, Blue }
Colors color = Colors.Green;

string name = color.GetName(); // 取得列舉值的名稱 "Green"
```

2. `ToEnum`
```csharp
public static TEnum ToEnum<TEnum>(this string str) where TEnum : struct, Enum
```
```csharp
string colorName = "Blue";
Colors color = colorName.ToEnum<Colors>(); // 將字串轉換為列舉值 Colors.Blue
```

3. `ToLower`
```csharp
public static string ToLower(this string source, int index)
```
```csharp
string input = "HELLO";
string result = input.ToLower(0); // 將索引 0 的字母轉為小寫，結果為 "hELLO"
```

4. `Remove`
```csharp
public static void Remove(this StringBuilder source, string str)
```
```csharp
var builder = new StringBuilder("Hello, World!");
builder.Remove("World"); // 移除 "World" 子字串，結果為 "Hello, !"
```

---

### Time Extensions

1. `GetRemainingSeconds`
```csharp
public static double GetRemainingSeconds(this DateTime date)
```
```csharp
DateTime now = DateTime.Now;
double remainingSeconds = now.GetRemainingSeconds(); // 計算當天剩餘秒數
```

2. `GetDifferenceInSeconds`
```csharp
public static double GetDifferenceInSeconds(this TimeSpan span, TimeSpan value)
```
```csharp
TimeSpan start = TimeSpan.FromHours(3);
TimeSpan end = TimeSpan.FromHours(5);

double difference = end.GetDifferenceInSeconds(start); // 計算兩時間差的秒數
```

## 文件說明
每個擴充方法都包含詳細的 XML 註解，提供方法的用途、參數及回傳值說明。您可透過 Visual Studio 的 IntelliSense 或其他 IDE 查看詳細資訊，提升開發效率。

## 授權
此專案基於 GPLv3 授權條款，詳情請參閱 LICENSE 文件。
