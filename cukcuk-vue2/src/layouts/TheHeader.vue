<template lang="">
    <header>
			<div class="head-selector">
				Nhà hàng biển Đông
				<img class="defaul-icon drop-down-icon" src="../assets/icon/down.png" />
			</div>
			<div class="head-account">
				<img class="defaul-icon bell-icon" src="../assets/icon/bell.png" />
				<img class="defaul-icon avt-icon" src="../assets/img/avatar-default.png"/>
				Hoàng Nhật Minh
				<img class="defaul-icon" src="../assets/icon/option.png"/>
			</div>
		</header>
</template>
<script>
export default {
    
}
</script>
<style lang="css" scoped>
header {
	box-sizing: border-box;
	width: 100%;
	min-height: 48px;
	background-color: #fff;
	border-bottom: 1px solid #BBBBBB;
}
	.head-selector,.head-account{
		height:100%;
		display: flex;
		align-items:center;
	}
	.head-selector{
		float:left;
		min-width:26px;
		margin-left:16px;
		font-family:'GoogleSans Bold';
	}
		.head-selector:hover{
			cursor:pointer;
		}
	.head-account {
		float:right;
		min-width: 64px;
		margin-right:16px;
		font-family:'GoogleSans Medium'
	}
</style>