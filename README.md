---
title: C# gRPC Server
tags:
date:
categories:
---

# gRPCSimple
嘗試 .net core 提供的 gRPC框架
# 重點步驟
1. 先建立 proto 檔，並編寫相關規範
![](https://i.imgur.com/fmWBnYq.png)
    
    proto 本人
    形態要稍微注意一下，詳情可見[Google 開發手冊](https://developers.google.com/protocol-buffers/docs/proto3)
    
    
    ```csharp= 
    syntax = "proto3";
    //syntax grpc 版本 
    //proto 檔會轉成預設命空間
    option csharp_namespace = "GrpcServiceCRUD";

    package greet;

    // The greeting service definition.
    // 實作service 時需要繼承這個東西 
    service Greeter {
      // Sends a greeting
      // 定義 rpc Method [request] returns [response]
      rpc SayHello (HelloRequest) returns (HelloReply);
    }

    // The request message containing the user's name.
    message HelloRequest {
      //[型別 屬性名 = 順序]
      //這裡的1不是付值是順序!!!
      string name = 1;
    }

    // The response message containing the greetings.
    message HelloReply {
      string message = 1;
    }
    ```
    
3. 使用 .Net gRPC 框架建立 gRPC Server 服務
    記得在 csproj 中指定 prote 使用 CodeGen 自動產生 Class
    GrpcServices > Server 端就選 Server
```csharp=
<ItemGroup>
    <Protobuf Include="Protos\greet.proto" GrpcServices="Server" />
    <Protobuf Include="Protos\Algorithm.proto" GrpcServices="Server" />
</ItemGroup>
```   
5. 實作服務

繼承 Greeter.GreeterBase 完成相關操作 
![](https://i.imgur.com/Ui56Tst.png)

7. 將服務發行
     在 Program.cs 中註冊服務
    ```csharp=
    app.MapGrpcService<GreeterService>();
    app.MapGrpcService<AlgorithmerService>();
    ```

9. 在 Client 端取得 proto 檔
    將寫好的 Proto 移至要實作的 Client
![](https://i.imgur.com/OjDVuyp.png)

11. 使用 .Net gRPC 框架建立 gRPC Clinet 端
    記得在 csproj 中指定 prote 使用 CodeGen 自動產生 Class
    GrpcServices > Client 端就選 Client
    ```csharp=
      <ItemGroup>
        <Protobuf Include="Protos\greet.proto" GrpcServices="Client" />
        <Protobuf Include="Protos\Algorithm.proto" GrpcServices="Client" />
      </ItemGroup>
    ```
    
13. 連線並呼叫相關的操作  
![](https://i.imgur.com/adW0Q9f.png)
