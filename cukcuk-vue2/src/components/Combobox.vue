<template>
<div @focusout="displaySelection(false)"> 
<div class="combobox" >
    <input v-model="selection" class="combobox-input" @focusin="displaySelection(true)"/>
    <button class="combobox-btn" @click="onClickComboboxBtn"
		@mouseenter="locked=true" @mouseleave="locked=false" ></button>
    <div class="combobox-select" v-show="isShowSelections" 
		@mouseenter="locked=true" @mouseleave="locked=false">
        <div class="combobox-item"
            v-for="selection in selections"
            @click="onClickComboboxItem"
            :key="selection"
        >{{selection}}</div>
    </div>
</div>
</div>
</template>
<script>
export default {
    name:"Combobox",
    data(){
        return{
            isShowSelections: false,
			locked: false,
            selection: null,
            selections: [],
            items: null
        }
    },

    props:{
        dataForSelections: Array
    },

    created(){
        // Gán sự kiện, gán event ở đây
        var me=this;
        me.selections = me.dataForSelections;
        me.selection = me.selections[0];	
    },

    mounted(){
        // Truy cập DOM ở đây
        var me=this;
        me.items = me.$el.getElementsByClassName('combobox-item');
        me.items[0].classList.add('combobox-item-selected');
    },

    updated(){
        var me=this; 
        if(me.isShowSelections==true){
            me.$el.querySelector('.combobox-btn').classList.add('combobox-btn-selected');
            for(var i of me.items){
                if(i.textContent==me.selection) i.classList.add('combobox-item-selected');
                else i.classList.remove('combobox-item-selected');
            }
        } else {
            this.$el.querySelector('.combobox-btn').classList.remove('combobox-btn-selected');
        }
    },

    methods: {
        onClickComboboxBtn: function(){
			this.isShowSelections= !this.isShowSelections;
        },
        onClickComboboxItem: function(event){
            this.selection = event.target.textContent;
            this.isShowSelections = false;
        },
        displaySelection(value){
            if(this.locked) return;
			this.isShowSelections = value;
        }
    }
}
</script>


<style lang="css">
@import url("../css/common/google-sans.css");
.combobox, .combobox-btn, .combobox-item, .combobox-input{
	border-radius: 4px;
}
.combobox {
    z-index: 3;
	position: relative; /*Neu khong co dong nay, combobox-select se tran ra theo body*/
    display: flex;
	box-sizing: border-box;
	width: 213px;
	height: 40px;
	border: 1px solid #bbbbbb;
	background-color: #fff;
}
	.combobox:hover {
		cursor: pointer;
	}
	.combobox:focus-within {
		border: 1px solid #019160;
	}

	.combobox-input {
		width: calc(100% - 40px);
		height: 100%;
		border: none;
		outline: none;
		padding: 0 16px 0 16px;
		box-sizing: border-box;
		border: none;
		color: #000;
		font-size: 13px;
		font-family: GoogleSans;
		font-size: 13px;
		
	}
	.combobox-btn {
		padding:0;
		border:none;
		box-sizing:border-box;
		width: 40px;
		height: 100%;
		background-image: url("../assets/icon/down.png");
		background-position: 12px center;
		background-repeat: no-repeat;
		background-size: 16px 16px;
		background-color: #fff;
	}
	.combobox-btn:hover{
		background-color:#E9EBEE;
	}
	.combobox-btn-selected{
		background-image: url('..//assets/icon/up.png');
	}
	.combobox .combobox-select{
		box-sizing: border-box;
		width: 100%;
		position: absolute;
		top:40px;
		border: 1px solid #bbb;
		border-radius: 4px;
		background-color: #fff;
		display: block;
	}
		.combobox .combobox-select .combobox-item{
			padding-left: 36px;
			height: 40px;
			box-sizing: border-box;
			display: flex;
			align-items: center;
		}
		.combobox .combobox-select .combobox-item:hover{
			background-color: #e9ebee;
			cursor: pointer;
			color:#000;
		}
		.combobox .combobox-select .combobox-item-selected, .combobox-item-selected:hover{
			color:#fff !important;
			background: #019160 url('..//assets/icon/down.png') no-repeat 10px center !important;
			background-size: 16px 16px !important;
		}
</style>