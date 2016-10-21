# ITServices
<strong>•	Project title</strong>: Customer Information System<br/ >

<strong>Application type</strong>: Web Based Application<br/ >

<strong>Tools</strong>: C#, ASP.NET MVC (EF and Code First), SQL Server database, HTML, CSS, jQuery, AJAX, JSON, Bootstrap and Crystal Report.<br/ >

<strong>Short Description</strong>: An IT company is dealing with software development, maintenance and support (services category). It needs a customer database with basic contact information and contract type. I build a web application to add/update/delete customer including preview and print of customer list having different criteria. <br/ >
<br/ ><strong>Customer Data:</strong> 
Code|Name| Address|PostCode|Region|Telephone|Email|Contact Person Name|Contact Person Positon(from a designation table[DesigId, DesigName])|Region[from a region table]|Category (from a category table [CatId, CatName])<br/ >
<br/ ><strong>Project functionalities are:</strong> 
1.	Four command buttons are New, Delete, Preview and Exit.<br/ >
2.	After pressing New it will change to Save. Delete and Preview will be disabled.<br/ >
3.	If a new Code of customer entered all fields will be cleared. User the entry data and ask.<br/ >
4.	After giving an existing Code of customer in Code field all information will be displayed and new button will be change to Update. Delete and Preview button will be enabled.<br/ >
5.	If user change any data and click on Update button the system will ask for confirmation. If confirmed then the record will be updated with new data.<br/ >
6.	If user click on delete it will ask for confirmation. If confirm then customer record will be deleted. Delete button again disabled.<br/ >
7.	After click in Preview button the system will pop up having (i) a list of all region in a combo box and a check box beside it and (ii) a list of all category in a combo box and a check box beside it. It will also have three button named “Show”, “Print” and “Cancel”. If user select a region the list will be filtered. If check boxed is checked then no filter applied.<br/ >
