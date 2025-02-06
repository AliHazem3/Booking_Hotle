// Declaration
let NameBooking = document.getElementById('NameBooking');
let roomTypeName = document.getElementById('roomTypeName');
let price = document.getElementById('price');
let Discount = document.getElementById('Discount');
let total = document.getElementById('total');
let numberOfAdults = document.getElementById('numberOfAdults');
let nOfchildern = document.getElementById('nOfchildern');

let UrlPro = 'http://localhost:5133/api/Rooms';

 
function GetTotal() {
    // Get input values
    let roomPrice = parseFloat(price.value) || 0;
    let discount = parseFloat(discount.value) || 0;
    let numberOfAdults = parseFloat(numberOfAdults.value) || 0;
    let numberOfChildren = parseFloat(nOfchildern.value) || 0;

     
    let baseTotal = roomPrice * (numberOfAdults + numberOfChildren) - discount;

     
    if (checkbox.checked) {
        let additionalDiscount = baseTotal * 0.05;  
        baseTotal -= additionalDiscount;
    }

    // Update the total price field
    totalPrice.value = baseTotal.toFixed(2);  

   
    if (baseTotal > 0) {
        totalPrice.className = 'form-control bg-warning text-center';
    } else {
        totalPrice.className = 'form-control bg-danger text-center';
    }
};



//Save function
function SaveProduct (){   
let objProduct={
    categoryId: dddlcategory.value,   
    name: product.value,
    quntity: quntity.value,
    price: price.value,
    descount: descount.value,
    total: total.value

};

 let data=JSON.stringify(objProduct); // convert string to json to accepte in ajax
 if(ValidationProduct() == false){
    return;
 }
 Helper.AjaxCallPost(UrlPro,data, function(data) {      

    if(data !=null){
        toastr.success(`Save the New Product ${data.name}`, 'Successfully');
        RestProduct();
        showTable();// after save show use fuction table  to save in table
        countProduct();
  
    }else{
        toastr.error(`Not Save the New Product ${data.name}`, 'Error');
    }
 });



};


 

 //Rest function
RestProduct= ()=>{
 

total.className.replace='form-control bg-warning text-center';
total.className='form-control bg-danger text-center';

};

//showtable function

function showTable()
{
    let TableProduct= '';

   
  $.ajax({
    url : `${UrlPro}`,
    method: 'GET',
    cache:false,
    success: function(data){

        data.forEach(element => {
            TableProduct +=`
                        <tr>
                        <td>${}</td>
                        <td>${}</td>
                        <td>${} </td>
                        <td>${}</td>
                        <td>${}</td>
                        <td>${}</td>
                        <td>${}</td>
                        <td>
                            <button class="btn btn-info">
                                <i class="fa-solid fa-pen-to-square"></i>
    
                            </button>
                            <button class="btn btn-danger" onclick="DeleteProduct(${element.id})" >
                                <i class="fa-solid fa-trash"></i>
    
                            </button>
                        </td>
                        
                    </tr>
                    `;
                });
                bodyProduct.innerHTML=TableProduct;
    }
  });

};


//count function in head Title

function countProduct(){
 $.ajax({
    url: `${UrlPro}`,
    method: 'GET',
    cache: false,
    success: function(data){
        CountProducts.innerHTML=`-TotalNumber(${data.length})`;
    } 
 });

};


//Delete function

function  DeleteProduct(id){

     if(confirm('Are You Sure You Want To Delete')== true){
        $.ajax({
            url: `${UrlPro}/${id}`,
            method: 'DELETE',
            cache: false,
            success: function(data){
                if(data !=null){
                    showTable();
                    countProduct();
                    toastr.error('Delete the Category is Name ' + data.name, 'DELETE');
                } 
                
            }
    
        });
     }

};


//Validation



//prnt function

//Event Run







price.addEventListener('input', GetTotal);
discount.addEventListener('input', GetTotal);
numberOfAdults.addEventListener('input', GetTotal);
nOfchildern.addEventListener('input', GetTotal);
checkbox.addEventListener('change', GetTotal);
