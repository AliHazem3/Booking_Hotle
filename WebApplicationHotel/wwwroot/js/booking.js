
let NameBooking = document.getElementById('NameBooking');  
let NationalIdBook = document.getElementById('NationalIdBook');
let PhoneNoBook = document.getElementById('PhoneNoBook'); 
let BranchBook = document.getElementById('BranchBook'); 
let CheckIn = document.getElementById('CheckIn'); 
let CheckOut = document.getElementById('CheckOut'); 
let NoOfRooms = document.getElementById('NoOfRooms'); 
let checkbox = document.getElementById('checkbox');
let btnSaveBook = document.getElementById('btnSaveBook');
let btnDownloadBooking = document.getElementById('btnDownloadBooking');

let bodyCate = document.getElementById('bodyCate'); 
//let countCategory= document.getElementById('CountCategory');
let Url ='http://localhost:5133/api/Bokings';
 
 


function SaveBooking() {
    let objBooking = {
        customerName: NameBooking.value,
        nationalId: NationalIdBook.value,
        phoneNumber: PhoneNoBook.value,
        hotelBranch: BranchBook.value,
        checkInDate: CheckIn.value,
        checkOutDate: CheckOut.value,
        numberOFRooms: NoOfRooms.value,
        hasBookedBefore: checkbox.checked,
    };

    let data = JSON.stringify(objBooking); // convert data from JSON to String

    $.ajax({
        url: `${Url}/Save`, // Corrected template literal syntax
        method: 'POST',
        contentType: 'application/json',
        data: data,
        cache: false,
        success: function (response) { // Use 'response' or another meaningful variable name
            RestCategory();;
            alert('Booking saved successfully!'); // Display a success message
            console.log(response); // Log the response from the server
        },
        error: function (xhr, status, error) {
            alert('An error occurred while saving the booking.'); // Display an error message
            console.error(error); // Log the error to the console
        }
    });
}


// BookingDetails
function BookingDetails() {
    let Table = '';

    $.ajax({
        url: `${Url}/GetAll`,
        method: 'GET',
        cache: false,
        success: function (response) {
            response.forEach(function (item) {
                Table += `
       <tr>
       <td> ${item.id}</td>
       <td> ${item.customerName}</td>
       <td> ${item.nationalId}</td>
       <td> ${item.hotelBranch}</td>
       <td> ${item.checkOutDate}</td>
       <td> ${item.numberOFRooms}</td>
       <td> ${item.customerName}</td>
       <td> ${item.hasBookedBefore}</td>
       
       <td>
       <button class="btn btn-danger" onclick="DeleteBooking(${item.id})">
       <i class="fa-solid fa-trash"></i>
      </button>
       </td>
       </tr>
       `;
            });

            bodyCate.innerHTML = Table;
        },
        error: function (xhr, status, error) {
            console.error(error); // Log the error to the console
        }
    });
}


//RestBooking
function RestCategory() {
    NameBooking.value = '';
    NationalIdBook.value = '';
    PhoneNoBook.value = '';
    BranchBook.value = '';
    CheckIn.value = '';
    CheckOut.value = '';
    NameBooking.value = '';
    checkbox.checked = '';

 
};



function DeleteBooking(id) {    // we use this function in button  download category name
    if (confirm('Are you Sure From deleted...?') == true) {
        $.ajax
            ({
                url: `${Url}/${id}`, //  Note didn't use ${Url}/Delete because didn't change the name in control api delete
                method: 'DELETE',
                cache: false,
                success: function (response) {
                    BookingDetails(); // calling this function after delete to show table                  
                    toastr.error(`Success Delete Row Category  (${data.name})`, 'DELETE');
                }
            });

    }
};

 


btnSaveBook.addEventListener('click', SaveBooking);
btnDownloadBooking.addEventListener('click', BookingDetails);
BookingDetails();