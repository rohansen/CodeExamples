using NavisionCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavisionCore.Interfaces
{
    
    public interface INavisionRepository
    {


        //Information to create interface and domain classes (paste json as c#)

        //Endpoints (https://docs.microsoft.com/en-us/dynamics-nav/endpoints-apis-for-dynamics)

        //HTTP methods here (https://docs.microsoft.com/en-us/dynamics-nav/fin-graph/)

        //Commplex type datastructures in json here (https://docs.microsoft.com/en-us/dynamics-nav/fin-graph/resources/dynamics_complextypes)

        //Error codes: (https://docs.microsoft.com/en-us/dynamics-nav/fin-graph/dynamics_error_codes)

        //GET /businesscentral/companies({id})/accounts({id})
        //
        //GET /businesscentral/companies({id})/agedAccountsPayable
        //
        //GET /businesscentral/companies({id})/agedAccountsReceivable
        //
        //GET /businesscentral/companies({id})/balanceSheet
        //
        //GET /businesscentral/companies({id})/cashFlowStatement
        //
        //GET /businesscentral/companies
        //
        //GET /businesscentral/companies({id})/companyInformation({id})
        //PATCH /businesscentral/companies({id})/companyInformation({id})
        //
        //GET /businesscentral/companies({id})/countriesRegions({id})
        //POST /businesscentral/companies({id})/countriesRegions
        //PATCH /businesscentral/companies({id})/countriesRegions({id})
        //DELETE /businesscentral/companies({id})/countriesRegions({id})
        //
        //GET /businesscentral/companies({id})/currencies({id})
        //POST /businesscentral/companies({id})/currencies
        //PATCH /businesscentral/companies({id})/currencies({id})
        //DELETE /businesscentral/companies({id})/currencies({id})
        //
        //GET /businesscentral/companies({id})/customers({id})
        //POST /businesscentral/companies({id})/customers
        //PATCH /businesscentral/companies({id})/customers({id})
        //DELETE /businesscentral/companies({id})/customers({id})
        //
        //GET /businesscentral/companies({id})/customerPaymentsJournals({id})/customerPayments({id})
        //POST /businesscentral/companies({id})/customerPaymentsJournals({id})/customerPayments({id})
        //PATCH /businesscentral/companies({id})/customerPaymentsJournals({id})/customerPayments({id})
        //DELETE /businesscentral/companies({id})/customerPaymentsJournals({id})/customerPayments({id})
        //
        //GET /businesscentral/companies({id})/customerPaymentsJournals({id})
        //POST /businesscentral/companies({id})/customerPaymentsJournals({id})
        //PATCH /businesscentral/companies({id})/customerPaymentsJournals({id})
        //DELETE /businesscentral/companies({id})/customerPaymentsJournals({id})
        //
        //GET /businesscentral/companies({id})/customerSales
        //
        //GET /businesscentral/companies({id})/dimensions({id})
        //
        //GET /businesscentral/companies({id})/dimensionLines?$filter=parentId eq ({id})
        //POST /businesscentral/companies({id})/dimensionLines
        //PATCH /businesscentral/companies({id})/dimensionLines(parentId=({id}),id=({id}))
        //DELETE /businesscentral/companies({id})/dimensionLines(parentId=({id}),id=({id}))
        //
        //GET /businesscentral/companies({id})/dimensions({id})/dimensionValues({id})
        //
        //GET /businesscentral/companies({id})/employees({id})
        //POST /businesscentral/companies({id})/employees
        //PATCH /businesscentral/companies({id})/employees({id})
        //DELETE /businesscentral/companies({id})/employees({id})
        //
        //GET /businesscentral/companies({id})/generalLedgerEntries({id})
        //
        //GET /businesscentral/companies({id})/incomeStatement
        //
        //GET /businesscentral/companies({id})/irs1099Codes({id})
        //POST /businesscentral/companies({id})/irs1099Codes
        //PATCH /businesscentral/companies({id})/irs1099Codes({id})
        //DELETE /businesscentral/companies({id})/irs1099Codes({id})
        //
        //GET /businesscentral/companies({id})/items({id})
        //POST /businesscentral/companies({id})/items
        //PATCH /businesscentral/companies({id})/items({id})
        //DELETE /businesscentral/companies({id})/items({id})
        //
        //GET /businesscentral/companies({id})/itemCategories({id})
        //POST /businesscentral/companies({id})/itemCategories
        //PATCH /businesscentral/companies({id})/itemCategories({id})
        //DELETE /businesscentral/companies({id})/itemCategories({id})
        //
        //GET /businesscentral/companies({id})/journals({id})
        //POST /businesscentral/companies({id})/journals({id})
        //PATCH /businesscentral/companies({id})/journals({id})
        //DELETE /businesscentral/companies({id})/journals({id})
        //
        //GET /businesscentral/companies({id})/journals({id})/journalLines({id})
        //POST /businesscentral/companies({id})/journals({id})/journalLines({id})
        //PATCH /businesscentral/companies({id})/journals({id})/journalLines({id})
        //DELETE /businesscentral/companies({id})/journals({id})/journalLines({id})
        //
        //GET /businesscentral/companies({id})/paymentMethods({id})
        //POST /businesscentral/companies({id})/paymentMethods
        //PATCH /businesscentral/companies({id})/paymentMethods({id})
        //DELETE /businesscentral/companies({id})/paymentMethods({id})
        //
        //GET /businesscentral/companies({id})/paymentTerms({id})
        //POST /businesscentral/companies({id})/paymentTerms
        //PATCH /businesscentral/companies({id})/paymentTerms({id})
        //DELETE /businesscentral/companies({id})/paymentTerms({id})
        //
        //GET /businesscentral/companies({id})/purchaseInvoices({id})
        //POST /businesscentral/companies({id})/purchaseInvoices
        //PATCH /businesscentral/companies({id})/purchaseInvoices({id})
        //DELETE /businesscentral/companies({id})/purchaseInvoices({id})
        //
        //GET /businesscentral/companies({id})/purchaseInvoices({id})/purchaseInvoiceLines(documentId=({id}),sequence=({number}))
        //POST /businesscentral/companies({id})/purchaseInvoices({id})/purchaseInvoiceLines
        //PATCH /businesscentral/companies({id})/purchaseInvoices({id})/purchaseInvoiceLines(documentId=({id}),sequence=({number}))
        //DELETE /businesscentral/companies({id})/purchaseInvoices({id})/purchaseInvoiceLines(documentId=({id}),sequence=({number}))
        //
        //GET /businesscentral/companies({id})/retainedEarningsStatement
        //
        //GET /businesscentral/companies({id})/salesInvoices({id})
        //POST /businesscentral/companies({id})/salesInvoices       
        //PATCH /businesscentral/companies({id})/salesInvoices({id})
        //DELETE /businesscentral/companies({id})/salesInvoices({id})
        //
        //GET /businesscentral/companies({id})/salesInvoices({id})/salesInvoiceLines(documentId=({id}),sequence=({number}))
        //POST /businesscentral/companies({id})/salesInvoices({id})/salesInvoiceLines
        //PATCH /businesscentral/companies({id})/salesInvoices({id})/salesInvoiceLines(documentId=({id}),sequence=({number}))
        //DELETE /businesscentral/companies({id})/salesInvoices({id})/salesInvoiceLines(documentId=({id}),sequence=({number}))        
        //
        //GET /businesscentral/companies({id})/salesCreditMemos({id})
        //POST /businesscentral/companies({id})/salesCreditMemos
        //PATCH /businesscentral/companies({id})/salesCreditMemos({id})
        //DELETE /businesscentral/companies({id})/salesCreditMemos({id})
        //
        //GET /businesscentral/companies({id})/salesCreditMemos({id})/salesCreditMemoLines(documentId=({id}),sequence=({number}))
        //POST /businesscentral/companies({id})/salesCreditMemos({id})/salesCreditMemoLines
        //PATCH /businesscentral/companies({id})/salesCreditMemos({id})/salesCreditMemoLines(documentId=({id}),sequence=({number}))
        //DELETE /businesscentral/companies({id})/salesCreditMemos({id})/salesCreditMemoLines(documentId=({id}),sequence=({number}))
        //
        //GET /businesscentral/companies({id})/salesOrders({id})
        //POST /businesscentral/companies({id})/salesOrders
        //PATCH /businesscentral/companies({id})/salesOrders({id})
        //DELETE /businesscentral/companies({id})/salesOrders({id})
        //
        //GET /businesscentral/companies({id})/salesOrders({id})/salesOrderLines(documentId=({id}),sequence=({number}))
        //POST /businesscentral/companies({id})/salesOrders({id})/salesOrderLines
        //PATCH /businesscentral/companies({id})/salesOrders({id})/salesOrderLines(documentId=({id}),sequence=({number}))
        //DELETE /businesscentral/companies({id})/salesOrders({id})/salesOrderLines(documentId=({id}),sequence=({number}))
        //
        //GET /businesscentral/companies({id})/salesQuotes({id})
        //POST /businesscentral/companies({id})/salesQuotes
        //PATCH /businesscentral/companies({id})/salesQuotes({id})
        //DELETE /businesscentral/companies({id})/salesQuotes({id})
        //
        //GET /businesscentral/companies({id})/salesQuotes({id})/salesQuoteLines(documentId=({id}),sequence=({number}))
        //POST /businesscentral/companies({id})/salesQuotes({id})/salesQuoteLines
        //PATCH /businesscentral/companies({id})/salesQuotes({id})/salesQuoteLines(documentId=({id}),sequence=({number}))
        //DELETE /businesscentral/companies({id})/salesQuotes({id})/salesQuoteLines(documentId=({id}),sequence=({number}))
        //
        //GET /businesscentral/companies({id})/shipmentMethods({id})
        //POST /businesscentral/companies({id})/shipmentMethods
        //PATCH /businesscentral/companies({id})/shipmentMethods({id})
        //DELETE /businesscentral/companies({id})/shipmentMethods({id})
        //
        //GET /businesscentral/companies({id})/taxAreas({id})
        //POST /businesscentral/companies({id})/taxAreas({id})
        //PATCH /businesscentral/companies({id})/taxAreas({id})
        //DELETE /businesscentral/companies({id})/taxAreas({id})
        //
        //GET /businesscentral/companies({id})/taxGroups({id})
        //POST /businesscentral/companies({id})/taxGroups
        //PATCH /businesscentral/companies({id})/taxGroups({id})
        //DELETE /businesscentral/companies({id})/taxGroups({id})
        //
        //GET /businesscentral/companies({id})/trialBalance
        //
        //GET /businesscentral/companies({id})/unitsOfMeasure({id})
        //POST /businesscentral/companies({id})/unitsOfMeasure
        //PATCH /businesscentral/companies({id})/unitsOfMeasure({id})
        //DELETE /businesscentral/companies({id})/unitsOfMeasure({id})
        //
        //GET /businesscentral/companies({id})/vendors({id})
        //POST /businesscentral/companies({id})/vendors
        //PATCH /businesscentral/companies({id})/vendors({id})
        //DELETE /businesscentral/companies({id})/vendors({id})
        //
        //GET /businesscentral/companies({id})/vendorPurchases
        //













    }
}
