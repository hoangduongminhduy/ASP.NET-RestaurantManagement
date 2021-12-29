import Vue from 'vue'
import VueRouter from 'vue-router'

import Home from '../views/Home.vue'
import About from '../views/About.vue'
import Setting from '../views/Setting.vue'
import CustomerList from '../views/CustomerList.vue'
import EmployeeList from '../views/EmployeeList.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/home',
    name: 'Home',
    component: Home,
    meta: { title: 'Cukcuk - Tổng quan' }
  },
  {
    path: '/customer',
    name: 'CustomerList',
    component: CustomerList,
    meta: { title: 'Cukcuk - Khách hàng' }
  },
  {
    path: '/employee',
    name: 'EmployeeList',
    component: EmployeeList,
    meta: { title: 'Cukcuk - Nhân viên' }
  },
  {
    path: '/about',
    name: 'About',
    component: About
  },
  {
    path: '/setting',
    name: 'Setting',
    component: Setting,
    meta: { title: 'Cukcuk - Cài đặt' }
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

router.replace('/customer');
router.afterEach((to) => {
  Vue.nextTick(() => {
      document.title = to.meta.title || 'Cukcuk';
  });
});
export default router
