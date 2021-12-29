class BasePage{
    table;
    data;
    constructor(){
        this.loadData();
        this.initEvent();
    }

    initEvent(){
        // For combobox-item and combobox-btn
        Combobox.initEvent();

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

        // Focus on search input field
        $('.search-fields input')[0].focus();

        // For refresh btn
        $('.refresh-btn').click(this.loadData);

        // For add new btn (employee or customer)
        $('.add-btn').click(function () {
            $('.m-dialog').show();
            $('#firstDialogInput').focus();
        })
        // For close dialog form btn
        $('.m-dialog-close').click(function () {
            $('.m-dialog').hide();
        })

        // For click save-btn of add new dialog
        $('.save-btn').click(function(){
            // phải bind this để nó k trỏ vào button?
            // 1.Validate inputs
            if(CommonJS.Validator.checkRequire('.m-dialog')==true){
                if(CommonJS.Validator.checkFormat('.m-dialog')==true){
                    // 2.Build object
                    
                    let customer = CommonJS.Builder.customer('.m-dialog');
                    // 3.Call api to save data to database
                    CommonJS.DataProcessor.post(customer);
                } 
            }
            // 4.Reload data
            loadData(); 
            // 5.Hide dialog
            $('.m-dialog').hide();
        })

        // For double click on table row
        $('tbody').on('dblclick', 'tr', function(){  
            $('.add-btn').click();
        })



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
    }

    /**
     * Get data from API and build HTML table
     * Author: hnminh
     */
    loadData(){
        try{
            $(`${this.table} tbody`).empty();
            // goi API lay du lieu
            $.ajax({
                type: "GET",
                url: "url",
                data: "data",
                dataType: "dataType",
                success: function (response) {
                    
                },
                error:function (param) {  

                }
            });
            // build du lieu len table HTML
    

        } catch(error) {

        }       
    }


}