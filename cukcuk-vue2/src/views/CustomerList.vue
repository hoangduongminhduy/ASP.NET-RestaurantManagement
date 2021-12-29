<template>
  <div>
    <div class="main">
      <div class="add-bar">
        Danh sách khách hàng
        <button class="add-btn" @click="onClickAddBtn">Thêm khách hàng</button>
      </div>
      <div class="search-bar">
        <div class="search-fields">
          <input type="text" placeholder="Tìm kiếm theo Mã, Tên hoặc Số điện thoại" />
          <Combobox :dataForSelections="['Tất cả giới tính', 'Nam', 'Nữ', 'Khác']"/>
        </div>
        <div class="search-bar-btns">
          <button class="delete-btn" @click="onClickDelBtn">Xóa</button>
          <button class="refresh-btn" @click="onClickRefreshBtn"></button>
        </div>
      </div>
     
      <div class="grid" style="margin-top: 16px">
        <table id="customer-table" keyId="CustomerId" cellspacing="0" cellpadding="0" border="0" style="min-width: 100%">
          <thead>
            <tr>
              <th colspan="1" rowspan="1"></th>
              <th colspan="1" rowspan="1" class="align-center">#</th>
              <th colspan="1" rowspan="1" class="align-left" fieldName="CustomerCode">Mã khách hàng</th>
              <th colspan="1" rowspan="1" class="align-left" fieldName="FullName">Họ và tên</th>
              <th colspan="1" rowspan="1" class="align-center" fieldName="DateOfBirth" >Ngày sinh</th>
              <th colspan="1" rowspan="1" class="align-left" fieldName="Gender">Giới tính</th>
              <th colspan="1" rowspan="1" class="align-right" fieldName="PhoneNumber">Điện thoại</th>
              <th colspan="1" rowspan="1" class="align-left" fieldName="Email">Email</th>
              <th colspan="1" rowspan="1" class="align-left" fieldName="CompanyName">Tên công ty</th>
              <th colspan="1" rowspan="1" class="align-left" fieldName="Address">Địa chỉ</th>
              <th colspan="1" rowspan="1" class="align-right" fieldName="DebitAmount">Số tiền nợ</th>
              <th colspan="1" rowspan="1" class="align-left" fieldName="MemberCardCode">Mã thẻ thành viên</th>
              <th class="gutter" style="width: 6px"></th>
            </tr>
          </thead>
          <tbody>
            <tr
              v-for="customer in customers"
              :key="customer.CustomerId"
              @click="onClickRow(customer.CustomerId)"
              @dblclick="onDblClickRow(customer)"
            >
              <td colspan="1" rowspan="1" class="row-checkbox-wrapper"><div class="row-checkbox"></div></td>
              <td colspan="1" rowspan="1" class="align-center">{{customers.indexOf(customer)+1}}</td>
              <td class="align-left">{{ customer.CustomerCode }}</td>
              <td class="align-left">{{ customer.FullName }}</td>
              <td class="align-center">{{ customer.DateOfBirth | formatDate }}</td>
              <td class="align-left">{{ customer.Gender | formatGender }}</td>
              <td class="align-right">{{ customer.PhoneNumber | formatNumber }}</td>
              <td class="align-left">{{ customer.Email }}</td>
              <td class="align-left">{{ customer.CompanyName }}</td>
              <td class="align-left">{{ customer.Address }}</td>
              <td class="align-right">{{ customer.DebitAmount | formatMoney }}</td>
              <td class="align-left">{{ customer.MemberCardCode }}</td>
            </tr>
          </tbody>
        </table>
      </div>

      <div class="footer">
        <p>Hiển thị <b>01-10 / {{this.customers.length}}</b> lao động</p>
              <div class="page-bar">
                <button class="nav-page-btn nav-first" ></button>
                <button class="nav-page-btn nav-prev"></button>
                <button class="page-btn page-btn-focus">1</button>
                <button class="page-btn">2</button>
                <button class="page-btn">3</button>
                <button class="page-btn">4</button>
                <button class="nav-page-btn nav-next" ></button>
                <button class="nav-page-btn nav-last" ></button>
              </div>
        <p><b>10</b> lao động/trang</p>
      </div>

      <CustomerDialog 
        :formMode="formMode" 
        :customerId="selectedCustomerId" 
        @displayCustomerDialog="displayCustomerDialog"
        @addNewCustomer="addNewCustomer"
        @deleteCustomer="deleteCustomer"
      />
      <ToastMsg 
        :isShow="isShowToastMsg"
        :toastText="toastText"
        :toastType="toastType"
      />
    </div>
  </div>
</template>

<script>
  import CustomerDialog from "./CustomerDialog.vue";
  import Combobox from "../components/Combobox.vue";
  import ToastMsg from "../components/ToastMsg.vue";
  import Resource from "../Resource.js";
  import axios from "axios";
  export default {
    name: "customer-list",
    components: {
      CustomerDialog, Combobox, ToastMsg
    },
    data(){
      return{
        customers: [],
        customer: {},
        selectedCustomerId: null,
        selectedCustomerIds: [],
        firstName: "",
        formMode: Resource.FormMode.Hidden,
        isShowToastMsg: false,
        toastText: null,
        toastType: null,
      }
    },

    watch: {
      firstName: function (value) {
        this.customer.CustomerCode = value;
      },
    },

    created(){
      this.getData();
    },

    filters: {
      formatGender: function(value){
        return Resource.VN.Gender[value];
      },
      formatNumber(value){
        return value;
        // return value.replace(/\D/g,'');
      },
      formatDate: function (value) {
        if (value) {
          value = new Date(value);
          let date = value.getDate();
          let month = value.getMonth() + 1;
          let year = value.getFullYear();
          date = date < 10 ? `0${date}` : date;
          month = month < 10 ? `0${month}` : month;
          return `${date}/${month}/${year}`;
        } 
        else return "";
      },
      formatMoney: function (value) {
        if (value) {
          value = value.toLocaleString('vi-VI', { style: 'currency', currency: 'VND' });
          return value.substr(0, value.length-2);
        }
        else return "";
      },
    },

    methods: {
      /**
       * Event Handling areas
       */
      onClickAddBtn() {
        this.selectedCustomerId = null;
        this.displayCustomerDialog(Resource.FormMode.Add, null);
      },
      onClickDelBtn(){
        var me=this;
        while(me.selectedCustomerIds.length > 0){
          me.deleteARecord(me.selectedCustomerIds.pop());
        }
      },
      onClickRefreshBtn(){
        this.getData();
        var selectedRows = document.getElementsByClassName('row-selected');
        while(selectedRows.length > 0){
          for(var i=0; i<selectedRows.length; i++){
            selectedRows[i].classList.remove("row-selected");
          }
          selectedRows = document.getElementsByClassName('row-selected');
        }
        this.displayToastMsg(true, "Lấy dữ liệu xong", "info");
      },
      onClickRow(customerId){
        // get clicked row
        var clickedRow = event.target;
        var i=0; 
        const limit = 5;
        do{
          clickedRow = clickedRow.parentNode;
          if(i>limit) break; else i++;
        } while(clickedRow.tagName.toLowerCase() != 'tr');
        // check if row is selected or not
        if( ! clickedRow.classList.contains('row-selected')){
          // add customerId from array if it does not exist
          (this.selectedCustomerIds.indexOf(customerId) < 0)? this.selectedCustomerIds.push(customerId) : 0;
        } else {
          // remove customerId from array if it existed
          this.selectedCustomerIds = this.selectedCustomerIds.filter(id => id != customerId);
        }        
        clickedRow.classList.toggle('row-selected');
      },
      onDblClickRow(obj){
        this.displayCustomerDialog(Resource.FormMode.Edit, obj.CustomerId);
      },

      /**
       * Show, hide DIALOG, TOASTMSG
       */
      displayCustomerDialog(mode, customerId){
          this.formMode = mode;
          this.selectedCustomerId = customerId;
      },
      displayToastMsg(display, text, type){
        this.toastText = text;
        this.toastType = type;
        this.isShowToastMsg=display;
        if(display==true) setTimeout(() => {
          this.isShowToastMsg=false;
          this.toastType = null;  
        }, 2500);

      },

      /**
       * Add Edit Delete areas
       */
      addNewCustomer(newCustomer){
        this.postData(newCustomer);
      },
      deleteCustomer(customerId){
        this.deleteARecord(customerId);
        this.formMode = Resource.FormMode.Hidden;
      },

      /**
      * get, post data using API
      */
      getData(){
        var me = this;
        // Gọi API lấy dữ liệu:
        axios
          .get(`${Resource.apiCustomer}`)
          .then(function (res) {
            me.cnt = 0;
            me.customers = res.data;
          })
          .catch(function (res) {
            console.log(res);
          });
      },
      postData(newCustomer){
        var me=this;
        axios
				.post(`${Resource.apiCustomer}`, newCustomer)
				.then(function () {
					me.getData();
          me.displayToastMsg(true, "Thêm mới thành công", "success");
				})
				.catch(function () {
					me.displayToastMsg(true, "Xảy ra lỗi khi thêm", "fail");
				});
      },
      deleteARecord(customerId){
        var me=this;
        // Gọi API lấy dữ liệu:
        axios
          .delete(`${Resource.apiCustomer}${customerId}`)
          .then(function () {
            me.getData(); 
            me.displayToastMsg(true, "Đã xóa thành công", "success");
          })
          .catch(function () {
            me.displayToastMsg(true, "Xảy ra lỗi khi xóa", "fail");
          });
      }
    },
  }
</script>

<style lang="css" scoped>
.main {
  height: calc(100vh - 48px); /*Trừ đi header*/
	box-sizing: border-box;
	width: 100%;
	padding:16px 16px 0px 16px;
	background-color: #e9ebee;
	display:flex;
	flex-direction:column;
}
	.main .add-bar{
		width:100%;
		height:40px;
		line-height:40px;
		font-family:'GoogleSans Medium';
		font-size:20px;
	}
	.main .search-bar{
		margin-top:8px;
		width:100%;
		height:40px;
    display: flex;
    justify-content: space-between;
	}
		.search-bar .search-fields {
			float: left;
			width: 50%;
			height: 100%;
			display: flex;
			flex-direction: row;
		}
			.search-fields>*{
				margin-right: 16px;
			}
    .search-bar .search-bar-btn{
      float:right;
    }


.footer {
	min-height: 56px;
	background-color: #e5e5e5;
	width:100%;
	box-sizing:border-box;
	display:flex;
	flex-direction:row;
	justify-content:space-between;
	padding-left:22px;
	padding-right:22px;
	align-items:center;
}
	.footer .page-bar{
		display:flex;
		flex-direction:row;
		width:400px;
		height:100%;
		justify-content:space-between;
		align-items:center;
	}
</style>