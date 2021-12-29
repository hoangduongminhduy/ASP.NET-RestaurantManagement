<template lang="">
    <div class="navbar">
		<div class="navbar-head">
			<button class="grid-menu"></button>
			<img class="banner" src="../assets/img/cukcuk-logo.png"/>
		</div>
		
		<div class="navbar-items">
			<button class="navbar-item">
				<img class="navbar-item-icon" src="../assets/icon/dashboard.png" />
				Tổng quan
			</button>
            <router-link class="navbar-item navbar-item-focus" to="/customer">
				<img class="navbar-item-icon" src="../assets/icon/dic-employee.png" />
				Khách hàng
			</router-link>
			<router-link class="navbar-item" to="/employee">
				<img class="navbar-item-icon" src="../assets/icon/dic-employee.png"/>
				Nhân viên
			</router-link>
			<button class="navbar-item">
				<img class="navbar-item-icon" src="../assets/icon/setting.png" />
				Cài đặt
			</button>
		</div>
	</div>
</template>
<script>
export default {
    mounted(){
		var items = this.$el.getElementsByClassName('navbar-item');
		for(var item of items){
			item.addEventListener('click', function(){
				for(var item of items){
					item.classList.remove('navbar-item-focus');
				}
				this.classList.add('navbar-item-focus');
			})
		}
	}
}
</script>

<style lang="css">
	.navbar {
		box-sizing:border-box;
		min-width: 226px;
		height: 100vh;
		background-color: #fff;
		border-right: 1px solid #BBBBBB;
	}
		.navbar .navbar-head {
			padding: 12px 0px 12px 16px;
		}
		.navbar .navbar-items {
			display: flex;
			flex-direction: column;
		}
			.navbar .navbar-item {
				font-size: 13px;
				height: 44px;
				display: flex;
				flex-direction: row;
				align-items: center;
				color: #454545;
				border: none;
				background-color: #fff;
				padding: 0;
				border-radius: 0px;
				font-family:'GoogleSans Regular'
			}
				.navbar-item:hover {
					cursor: pointer;
					font-family: 'GoogleSans Regular';
					color: #000;
					background-color: #e5e5e5;
				}
				.navbar-item-focus,.navbar-item-focus:hover {
					font-family: 'GoogleSans Medium';
					background-color: #019160;
					color: #fff;
				}
				.navbar-item-icon {
					width: 20px;
					height: 20px;
					margin-left: 16px;
					margin-right: 10px;
				}
</style>