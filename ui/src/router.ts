import { createWebHistory, createRouter, NavigationGuardNext, RouteLocationNormalized } from 'vue-router';

import Index from '@/pages/index.vue';
import Login from '@/pages/login.vue';
import CreateStore from '@/pages/createStore.vue';
import Products from '@/pages/products.vue';
import Order from '@/pages/order.vue';
import Track from '@/pages/track.vue';

const routes = [
    { path: '/', component: Index },
    { 
        path: '/login', 
        component: Login,
        meta: { public: true }
    },
    { path: '/make-store', component: CreateStore },
    { path: '/products', component: Products },
    { path: '/orders', component: Order },
    { path: '/track', component: Track }
];

export const router = createRouter({
    history: createWebHistory(),
    routes,
});

router.beforeEach((to: RouteLocationNormalized, _, next: NavigationGuardNext) => {
    const isPublicRoute = to.meta?.public;


    if(isPublicRoute) {
        return next();
    }

    if(localStorage.getItem('jwt') === null || localStorage.getItem('user') === null) {
        return next('/login');
    }

    next();
});