# c--workshop

### 两种练习模式
1. 练习本身是一个项目
2. 项目有不同的main方法

### dotenet
- new (新建某种类型的项目)
    dotnet new TYPE -n PRJ
- build (编译应用，为运行做准备；一般在包含.csproj的项目目录或者包含.sln文件的目录执行)
   dotnet build
- run (在包含.csproj的目录下运行或者指定--project,它也会自动build项目)
 dotnet run
### csproj
一个目录，包含编译器需要的所有metadata，以致于构建项目；还有一些app需要编译和运行的文件。
### .sln
方案文件包含着一个或者多个项目的metadata，用于将多个项目文件组织到一个build里


C# 里''是字符，""是字符串；


C#里有两种类型的变量：引用类型和值类型

值类型可以是 bool, byte, char, decimal, 
double, enum, float, int, long, sbyte, short, struct, uint, ulong, 
and ushort，存储在stack的内存空间；引用类型在C# 里有string， array， class；

### 默认值
所有的引用类型默认是null；数字是0；bool是false，char是'\0',Enum是0；
可以是使用default

