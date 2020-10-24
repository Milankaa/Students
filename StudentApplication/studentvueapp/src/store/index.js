import Vuex from 'vuex';
import Vue from 'vue';
import Student from './modules/Students';
import Courses from './modules/Courses';


Vue.use(Vuex);

export default new Vuex.Store({
    modules: {
        Student,
        Courses
    }
})