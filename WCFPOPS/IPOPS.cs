﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFPOPS
{
    [ServiceContract]
    public interface IPOPS
    {
        // Create Operations
        [OperationContract]
        void AddSupplier(Supplier supplier);

        [OperationContract]
        void AddItem(Item item);

        [OperationContract]
        void MakeOrder(POMaster pOMaster, List<PODetail> pODetails);

        // Read Operations

        [OperationContract]
        List<Item> GetAllItems();

        [OperationContract]
        List<Supplier> GetAllSuppliers();

        [OperationContract]
        List<Order> GetAllOrders();

        // Update Operations

        [OperationContract]
        void UpdateSupplier(Supplier supplier);

        [OperationContract]
        void UpdateItem(Item item);

        // Delete Operations

        [OperationContract]
        void DeleteSupplier(string supplierNumber);

        [OperationContract]
        void DeleteItem(string itemCode);

        [OperationContract]
        void DeleteOrder(string purchaseOrderNO);
    }
}
