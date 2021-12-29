<template lang="">
    <div v-show="!isHiddenMode()" class="m-dialog">
		<div class="m-dialog-modal"></div>
		<div class="m-dialog-box"  style="width: 488px; height: 598.8px;">
			<div class="m-dialog-header">
				<div class="m-dialog-title">THÔNG TIN KHÁCH HÀNG</div>
				<div class="m-dialog-close" @click="onClickCloseBtn"></div>
			</div>
			<div class="m-dialog-content">
				<div class="input-area">
					<div class="row">
						<div  class="label-input">
							<p>Mã khách hàng (<span class="red-char">*</span>)</p>
							<input v-model="customer.CustomerCode" required fieldname='CustomerCode' class='dialog-input' id="firstDialogInput"/>
						</div>
						<div class="label-input">
							<p>Họ và tên (<span class="red-char">*</span>)</p>
							<input v-model="customer.FullName" required fieldname='FullName' class='dialog-input' />
						</div>
					</div>

					<div class="row">
						<div class="label-input">
							<p>Giới tính</p>
							<Combobox v-model="customer.Gender" :dataForSelections="['Nam', 'Nữ', 'Khác']" style="z-index:2"/>
						</div>
						<div class="label-input">
							<p>Ngày sinh</p>
							<input v-model="customer.DateOfBirth" fieldname='DateOfBirth' class='dialog-input' placeholder="dd/mm/yyyy" type="date"  min="1940-01-01" max="2015-12-31"/>
						</div>
					</div>

					<div class="row">
						<div class="label-input">
							<p>Tên công ty</p>
							<input v-model="customer.CompanyName" fieldname='companyName' class='dialog-input w-large' />
						</div>
					</div>

					<div class="row">
						<div class="label-input" >
							<p>Địa chỉ</p>
							<input v-model="customer.Address" fieldname='Address' class="dialog-input w-large"/>
						</div>
					</div>

					<div class="row">
						<div class="label-input">
							<p>Email</p>
							<input v-model="customer.Email" fieldname='Email' class='dialog-input' />
						</div>
						<div class="label-input">
							<p>Số điện thoại (<span class="red-char">*</span>)</p>
							<input v-model="customer.PhoneNumber" fieldname='PhoneNumber' class='dialog-input align-right' />
						</div>
					</div>

					<div class="row">
						<div class="label-input">
							<p>Số tiền nợ</p>
							<input v-model="customer.DebitAmount" fieldname='DebitAmount' class='dialog-input align-right' />
						</div>
						<div class="label-input">
							<p>Mã thẻ thành viên</p>
							<input v-model="customer.MemberCardCode" fieldname='MemberCardCode' class='dialog-input' />
						</div>
					</div>

				</div>
			</div>
			<div class="m-dialog-footer">
				<button v-show="isEditMode()" class="delete-btn" @click="onClickDelBtn">Xóa</button>
				<button class="cancel-btn" @click="onClickCloseBtn">Hủy</button>
				<button class="save-btn" @click="onClickSaveBtn">Lưu</button>
			</div>
		</div>
	</div>
</template>
<script>
import axios from "axios";
import Resource from "../Resource.js";
import Combobox from "../components/Combobox.vue";
export default {
    components:{
		Combobox
	},
	data() {
		return {
			customer: {	
				CustomerId:null,
				CustomerCode: null,
				FullName: null,
				PhoneNumber: null,
			},
		};
	},
	props: {
		customerId: {
			type: String,
			default: "",
		},
		formMode: Number
	},

	watch:{
		formMode: function(){
			var me=this;
			if(this.formMode != Resource.FormMode.Hidden) this.$nextTick(() => this.$el.querySelector('#firstDialogInput').focus());
			if(this.formMode == Resource.FormMode.Edit){
				axios
					.get(`${Resource.apiCustomer}${me.customerId}`)
					.then(function (res) {
						me.customer = res.data;
						var birth = new Date(me.customer.DateOfBirth);
						me.customer.DateOfBirth = birth.getYear() + '-' + birth.getMonth() + '-' + birth.getDay();
					})
					.catch(function () {
						console.log("api lỗi!");
					});
			} else if(this.formMode == Resource.FormMode.Add){
				delete me.customer.CustomerId;
				for(var field in me.customer){
					me.customer[field] = '';
				}
				me.customer.DateOfBirth = '2000-12-31';
			}
		}
	},

	methods:{
		onClickCloseBtn(){
			this.$emit("displayCustomerDialog", Resource.FormMode.Hidden, null);
		},

		onClickSaveBtn(){
			let me=this; 
			if (me.formMode==Resource.FormMode.Add) {
				me.customer = 
				me.$emit("addNewCustomer", me.customer);
			} else {
				// tinh nang sua
			}
		},

		onClickDelBtn(){
			this.$emit("deleteCustomer", this.customerId);
		},

		isEditMode(){
			return this.formMode==Resource.FormMode.Edit;
		},
		isHiddenMode(){
			return this.formMode==Resource.FormMode.Hidden;
		}
	}
}
</script>
<style lang="css">
</style>