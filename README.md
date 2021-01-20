# Handling wcf service exceptions using fault contracts and data contracts

n this article, we will see how we can use WCF fault contracts to handle exceptions. WCF gives you enough flexibility to handle exceptions and send required detail to clients. By default, WCF sends exception details to clients using SOAP FaultContract. 
The default FaultContract will allow you to set Message, Reason properties and throw it to clients.

Why we should use the FaultContract rather than using .Net exceptions?

Exceptions have limitations and security risks.

1. .Net exception can be used by only CLR supported languages so losing great WCF feature of interoperability.
1. Throwing exceptions can provide service implementation and private details to clients.
1. Exceptions are tightly coupled between clients and service.

## Projects

1. [Northwind WCF Services](https://github.com/geeksarray/handling-wcf-service-exceptions-using-fault-contracts/tree/main/NorthwindServices) - WCF Services with implementation of    Fault Contract.
1. [Client App](https://github.com/geeksarray/handling-wcf-service-exceptions-using-fault-contracts/tree/main/NorthwindApp) - It is a client application consuming WCF services and 
   using Fault contract response sent by WCF services.

Your project structure will be like this

![Add WCF Service reference](https://geeksarray.com/images/blog/ServiceRef.png)

For more details about implementation of FaultContract  see https://geeksarray.com/blog/handling-wcf-service-exceptions-using-fault-contracts

