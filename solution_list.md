# [.net Common Tested Code]

## [AutoResetEventAndCallbackIpynbTest](./AutoResetEventAndCallbackIpynbTest)

#AutoResetEvent #Callback function

AutoResetEvent範例，示範使用AutoResetEvent和回呼函式（Callback）的簡單多執行緒程式

<br>

## [AutoResetEventTimeOutIpynbTest](./AutoResetEventTimeOutIpynbTest)

#AutoResetEvent #Timeout

AutoResetEvent範例，示範使用 AutoResetEvent 時加入Time out機制，以避免無窮等待的情況

<br>

## [CancellationTokenIpynbTest](./CancellationTokenIpynbTest)

#CancellationToken #CancellationTokenSource #Task #Task.Delay

使用帶有TimeOut的CancellationToken範例，並示範帶入Task.Delay中，當TimeOut觸發會丟例外，另外token也有提供若狀態為Cancel時，則丟出例外的方法

<br>

## [ConcurrentDictionaryIpynbTest](./ConcurrentDictionaryIpynbTest)

#ConcurrentDictionary #執行緒安全

測試使用執行緒安全的Dictionary

<br>

## [ConcurrentQueueIpynbTest](./ConcurrentQueueIpynbTest)

#ConcurrentQueue #執行緒安全

測試使用執行緒安全的Queue

<br>

## [ConditionalAttributeTest](./ConditionalAttributeTest)

#條件式編譯 #ConditionalAttribute

測試如何使用 [Conditional("DEBUG")] 屬性，在 Debug 模式下條件性執行特定方法，並與 #if DEBUG 的條件式編譯進行比較

<br>

## [DataTableComputeIpynbTest](./DataTableComputeIpynbTest)

#DataTable #DataTable.Compute

示範使用DataTable.Compute，放入運算式字串進行運算，例如放入"1+2"的字串進去，該函式會分析並計算並返回數字3

<br>

## [DotNetIpynbTest](./DotNetIpynbTest)

#ipynb #Polyglot Notebooks

使用VS code並安裝延伸模組Polyglot Notebooks，可以用Jupyter notebook的形式，執行C#程式碼，當需要寫簡單或要驗證的程式時，就不必特地開一個C#專案

<br>

## [ExpandoObjectIpynbTest](./ExpandoObjectIpynbTest)

#ExpandoObject #IDictionary

測試使用Expando類別，該類別可以在程式執行中，動態的增減成員、方法等(如同JS的類別)

<br>

## [FakeEnumTest](./FakeEnumTest)

#Enum #模式匹配

利用物件繼承，加上C# 7的模式匹配語法糖，讓整體使用上，感覺像是一種可以帶參數的enum

<br>

## [FuncDictIpynbTest](./FuncDictIpynbTest)

#Dictionary #Action #Func

使用 Dictionary 儲存方法與參數的對應關係，方便根據命令字串選擇並執行對應的邏輯（原本是使用 if/else 來實現）。

<br>

## [LazyIpynbTest](./LazyIpynbTest)

#Lazy

Lazy類別測試，使用該類別可以在物件被使用時才被初始化

<br>

## [MulticastDelegateGetInvocationListTest](./MulticastDelegateGetInvocationListTest)

#MulticastDelegate #Action #GetInvocationList

示範使用Action來做委派，並將其與三個方法相關聯，再來演示調用委派，包括正常調用、反向調用和條件調用；最後使用GetInvocationList取得有聯繫的所有委派並且清除

<br>

## [ObjectDataSerializerTest](./ObjectDataSerializerTest)

#Serializer #XML #JSON #YAML

整理常用的序列化格式，將物件序列化為string或byte array，並存儲至檔案中；以及從檔案讀取字串或位元組陣列，再反序列化回物件

<br>

## [TaskWhenAnyTest](./TaskWhenAnyTest)

#Task #WhenAny

Task類別中的WhenAny函數使用測試，可用作Timeout(但是Task不會被取消，需增加Cancel機制)

<br>

## [WaitHandleipynbTest](./WaitHandleipynbTest)

#AutoResetEvent #CancelToken #CancelTokenSource #WaitHandle #WaitAny

示範將AutoResetEvent與CancelToken放進WaitHandle(父類) Ary中，並搭配WaitAny方法，用來控制異步的阻塞，並可在AutoResetEvent阻塞情況下，透過CancelToken解除阻塞，並做對應的處理；用以補足AutoResetEvent只有TimeOut機制，沒有取消機制的功能(未實現)

<br>

