 $(document).ready(function() {
    Combobox.play();
    employeePage = new EmployeePage();
    
})


class EmployeePage extends BasePage{
    constructor(){
        super();
        this.table = '#employee-table';
        this.api = 'http://cukcuk.manhnv.net/api/v1/Employees';
    }
    
    /**
     * Load data from API and build to HTML table
     * Author: hnminh (13/10/2021)
     * */
    loadData(){
        try{
            $.ajax({
                url:"http://cukcuk.manhnv.net/api/v1/Employees",
                method:"GET",
                data: null,
                dataType: 'json',
                contentType: 'application/josn',
                async:true
            }).done(function(res){
                data = res;
                CommonJS.showLoading();
                CommonJS.buildTable('#employee-table', data);
                CommonJS.hideLoading();
            }).fail(function (res) {  
                console.log(res);
            })
        }catch{

        }
    }

    /**
     * Load pseudo data
     * Author: hnminh (13/10/2021)
     * */
    loadDataOld() {
        // Call a function to generate pseudo data
        let employees = [
            {
                code: 'NV-999999',
                name: 'Hoàng Nhật Minh',
                sex: 'Nam',
                birth: new Date('2000-01-26') ,
                phone: '0353832349',
                email: 'boylove9x@gmail.com',
                position: 'Nhân viên',
                department: 'Phòng sản xuất',
                salary: 9500000,
                state: 'Đang làm việc'
            }
        ]

        // Build HTML from data gotten
        // Use `` instead of '' for multi line paragraph initialization
        for (const employee of employees) {
            // 1.Process data format to meet conventions:
            // Date
            let date = employee.birth.getDate();
            let birthString=null;
            if (date) {
                let month = employee.birth.getMonth() + 1;
                month = (month < 10) ? `0${month}` : month;
                let year = employee.birth.getYear() + 1900;
                birthString = `${date}/${month}/${year}`;
            } else {
               birthString = '';
            }
            
            // Money
            let money = employee.salary.toLocaleString('vi-VI', { style: 'currency', currency: 'VND' });

            // 2.Build HTML; $ at begging for not repeated if duplicate
            let strHTML = (`
            <tr>
                <td class="align-left small">${employee.code}</td>
                <td class="align-left">${employee.name}</td>
                <td class="align-left small">${employee.sex}</td>
                <td class="align-center small">${birthString||""}</td>
                <td class="align-right small">${employee.phone}</td>
                <td class="align-left">${employee.email||""}</td>
                <td class="align-left">${employee.position}</td>
                <td class="align-left">${employee.department}</td>
                <td class="align-right">${employee.salary}</td>
                <td class="align-left">${employee.state}</td>
            </tr>
            `);
            $('table tbody').append(strHTML);
        }
    }


    /**
	 * Init events for elements
	 * Author: hnminh (14/10/2021)
	 * */
    initEvents() {
        super();
        // For click navbar-item
        let navbarItems = document.getElementsByClassName('navbar-item');
        for (let item of navbarItems) {
            item.addEventListener('click', function(){
                for (let item of navbarItems) {
                    item.classList.remove('navbar-item-focus');
                }
                this.classList.add('navbar-item-focus');
            })
        }

        // For add new employee btn (jquery instead of pure JS)
        $('.add-btn').click(function () {
            $('.m-dialog').show();
        })

        // For refresh btn
        $('.refresh-btn').click(this.loadData); // remove () for executing only when clicked

        // For click page-btn at the footer
        let pageBtns = document.getElementsByClassName('page-btn');
        for (let item of pageBtns) {
            item.addEventListener('click', function(){
                for (let item of pageBtns) {
                    item.classList.remove('page-btn-focus');
                }
                this.classList.add('page-btn-focus');
            });
        }

        // For click save-btn of add new dialog
        $('.save-btn').click(function(){
            // phải bind this để nó k trỏ vào button??

            // 1.Validate data
            // Required fields
            const code = $('code-inp').val();
            const name = $('name-inp').val();
            if (code == "" || code == null) {
                $('code-inp').addClass('invalid-input');
                $('code-inp').attr('title','Thông tin này không được phép để trống'); //addAttr?
            } else {
                $('code-inp').removeClass('invalid-input');
                $('code-inp').removeAttr('title');
            }
            if (name == "" || name == null) {
                $('name-inp').addClass('invalid-input')
                $('name-inp').attr('title','Thông tin này không được phép để trống'); //addAttr?
            } else {
                $('name-inp').removeClass('invalid-input');
                $('name-inp').removeAttr('title');
            }
        
            // 2.Build object
            let employe = {
                
            };

            // 3.Call api to save data to database
            $.ajax({
                url:"http://cukcuk.manhnv.net/api/v1/Employees",
                method:"POST",
                data: JSON.stringify(employee),
                dataType: 'json',
                contentType: 'application/josn',
                async:false
            }).done(function(res){
                alert("Thêm mới thành công!");
                data = res;
            }).fail(function (res) {  
                console.log(res);
            })
        })

        // For close dialog form btn
        $('.m-dialog-close').click(function () {
            $('.m-dialog').hide();
        })
    }
}