Repository 是一种模式，锁定一个model，然后定义它所有可能得crud方法

不是说所有的entity都应该单独创建一个repository，因为有些实体单独存在是没有意义的。
比如 人和联系信息，人可以单独存在，但是联系信息单独存在没有意义。所以创建
repository的原则就是不是针对某个entity而是某个aggregate。

repository实际上作为业务逻辑和数据之间的抽象层，这样不会和ORm耦合。更容易测试

repository模式适用于简单的CRUD应用，因为它可以简化数据库的交互。但是EF已经足够简单的
去和数据库交互了。repository的模式备受关注的原因之一就是可以躲开和数据库的交互。ef已经允许这个功能了
repository的一个不好的地方在于有些不需要完全CRUD的model，仍然需要实现CRUD的抽象方法


CQRS在于读写分离。它不是要求某个类实现所有的CRUD操作。他是要求有request和query的models去适用于
特定的细节。

在CQRS里面通常操作分为两类：
1. Command 用于改变状态（create, update, delete）
2. Query 用于获取一些状态，但是不影响状态

dotnet add package Microsoft.EntityFrameworkCore.InMemory





