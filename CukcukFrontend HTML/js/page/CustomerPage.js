 $(document).ready(function() {
    let customerPage = new CustomerPage();
})


class CustomerPage extends BasePage{
    constructor(){
        super(); 
        this.table = '#customer-table';
        this.api = 'http://cukcuk.manhnv.net/api/v1/Customerss';
    }
    
    
    /**
	 * Init events for elements
	 * Author: hnminh (14/10/2021)
	 * */
    initEvent() {
        super.initEvent();
    }


    /**
     * Load data from API and build to HTML table
     * Author: hnminh (13/10/2021)
     * */
     loadData(){
        try{
            //super.loadData();
            $.ajax({
                url: 'http://cukcuk.manhnv.net/api/v1/Customerss',
                method:"GET",
                data: null,
                dataType: 'json',
                contentType: 'application/json',
                async:true
            }).done(function(res){
                //CommonJS.ComponentPresenter.showLoading(); 
                CommonJS.Builder.table('#customer-table', res); 
                //CommonJS.ComponentPresenter.hideLoading();
            }).fail(function (error) {  
                console.log('loadData fail CustomerPage.js');
            })
        }catch{
            console.log('catch error loadData Customer.js');
        }
    }
}