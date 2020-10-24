import axios from 'axios';

const url = 'https://localhost:44386/api';

const state = {
    courses: [],
    studentsOnCourse:[]
};
const getters = {
    allCourses: (state) => state.courses,
    allStudentsOnCourse: (state) => state.studentsOnCourse
};
const actions = {
    async getCourses({ commit }) {
        const response = await axios.get(url+'/course');
        commit('setCourses', response.data);
    },
    async getStudentsOnCourse({ commit }, courseId) {
        const response = await axios.get(url +`/course/getstudents/${courseId}`);
        commit('setStudentsOnCourse', response.data);
        
    },
    async addStudentToCourse({commit},studentInCourse) {
        axios.post(url+'/course/poststudent', studentInCourse);
        const id = studentInCourse.Student_id;
        const response = await axios.get(url+`/students/${id}`); 
        commit('addStudent', response.data);
        
        },
    addCourse({commit },title) {
        const response = axios.post(url+'/course/postcourse', { NazivKursa: title});
        commit('newCourse', response.data);
    }
};

const mutations = {
    setCourses: (state, courses) => (state.courses = courses),
    setStudentsOnCourse: (state, students) => (state.studentsOnCourse = students),
    addStudent: (state, student) => (state.studentsOnCourse.unshift(student)),
    newCourse:(state, title) => (state.courses.unshift(title))
};

export default {
    state,
    getters,
    actions,
    mutations
}; 