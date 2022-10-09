# JDGuardian
京东商品库存、价格监控

---

# 概述
将京东的接口简单二次封装，组合成需要的价格、库存、预约、秒杀监控功能，并将监控情况发送邮件通知。


# 已支持功能
- 查看商品信息
- 检查商品是否有库存、处于预约、秒杀中
- 监控商品是否有货，自动发送有货通知邮件

# 待开发功能

- 商品开始预约、秒杀监控
- 商品价格变化监控

实现方式与监控商品是否有货类似

---


# 使用

项目本质上就是个WebApi，一切操作都是基于swagger来操作。

## 环境要求

这是一个ASP.NET 6 WebApi项目，仅需要安装.Net 6运行环境，Linux、Windows均支持。

[.NET 6.0](https://dotnet.microsoft.com/zh-cn/download/dotnet/6.0)

下载ASP.NET Core 运行时即可。

## 配置发送通知的邮箱

发送监控情况需要指定发件人邮箱，在appsettings.json 配置文件中MailSetting节点配置。

- Address 发件人邮箱地址
- DisplayName 发件人名称
- Host 发件人Smtp服务地址
- Port Smtp端口
- EnableSsl 是否使用SSL通讯
- UserName 发件人账号名（一般为邮箱地址）
- Password 发件人账号密码（或邮箱授权码）

appsettings.json示例
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "MailSetting": {
    "Address": "xxx@qq.com",
    "DisplayName": "JDGuardian",
    "Host": "smtp.qq.com",
    "Port": 587,
    "EnableSsl": true,
    "UserName": "xxx@qq.com",
    "Password": "qwertyuiop"
  }
}


```

## 运行
执行JDGuardian即可，然后按以下地址进入swagger

- https://localhost:5003/swagger/index.html
- http://localhost:5002/swagger/index.html

swagger接口均已写明注释，不再重述。仅挑几个特别说明一下

### area 地区
京东查看商品价格、库存等信息都必须带上收货地址，这个area是一个地区id组合字符串，表示省、市、区等组合起来的地址，如19_1601_50258_51885表示了广东_广州_白云区_城区这个地址。

从接口area接口可以逐步获取到每个地区的下属地区，一直到没有下属地区为止，然后把前面每一步拿到的地区id拼起来就是一个有效的地区参数，但不用带上国家（至少中国不需要）。

### skuId 商品id
商品在京东内部的唯一id

### 添加库存监控参数
此时post过去的数据中，mail表示如果有货时将把通知邮件发到这个地址，span表示轮询间隔（检查是否有货实际上是不停地调用库存接口check/isStock），单位为秒。

```
{
   "mail": "qq@qq.com",
   "span": 60,
   "skuId": 100016148888,
   "area": "19_1601_50258_51885"
}
```

如上参数即表示商品100016148888如果在19_1601_50258_51885这个地区有货，将把通知邮件发送到邮箱qq@qq.com，每次间隔60s判断一次是否有货。

发送请求后，如果返回一个GUID字符串，则为添加成功，此时就会开始按指定间隔监控是否有货。

---

# 一些我用到的商品skuId
- XSX 100011513445
- XSX & 黑色游戏耳机套装 100016346817
- Xbox Series 手柄 磨砂黑 100016148888
- Xbox Series 手柄 磨砂黑 USB-C线缆 100016148810
- Xbox Series 手柄 磨砂黑 无线适配器 100016148908
- Xbox Series 手柄 冰雪白 100016148864
- Xbox Series 手柄 波动蓝 100009153053
- Xbox Series 手柄 极光蓝 100013915485
- Xbox Series 手柄 电光黄 100021197380
- Xbox Series 手柄 锦鲤红 100017833496
- Xbox 无线适配器 5028827

巨硬你能不能硬一回？！
