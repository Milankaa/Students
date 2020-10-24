import axios from 'axios';

const url = 'https://localhost:44386/api/students';
const state = {
    students: [],
    model: {
        Student_id: 0,
        Ime: "",
        Prezime: "",
        Godina: "",
        BrojIndeksa: "",
        StatusStudenta: 1,
        Kurs: []
    }
};  


const getters = {
    allStudents: (state) =>  state.students,
    StudentCourses: (state)=> state.courses
    
};
const actions = {
    async getStudents({ commit, getters }) {
        const response = await axios.get(url);
        commit('setStudents', response.data);
        console.log(getters.allStudents);
    },
    async getStudent({commit, state },id) {
        const response = await axios.get(url+`/${id}`);
        state.model = response.data;
        commit('setStudent', response.data);
        return state.model;
        
    },
    
     addStudent({ state, commit }) {
        axios.post(url, state.model);
        commit('newStudent', state.model);    
       
    },
    deleteStudent({ commit }, id) {
        axios.delete(url+`/${id}`);
        commit('delStudent', id);
    },
    updateStudent({ state, commit } ) {
        axios.put(url, state.model);
        commit('updStudent',state.model);
    }
};
const mutations = {
    setStudent: (state, student) => (state.model = student),
    setStudents: (state, students) => (state.students = students),
    setStudentCourses: (state, courses) => (state.courses = courses),
    newStudent: (state, student) => {
        state.students.unshift(student);
        state.model = {
            Student_id: 1,
            Ime: "",
            Prezime: "",
            Godina: "",
            BrojIndeksa: "",
            StatusStudenta: 1
        }
    },
    delStudent: (state, id) =>
        (state.students = state.students.filter(student => student.id !== id)),
    updStudent: (state, student) => {

        const index = state.students.findIndex(stud => stud.Student_id === student.Student_id);
        if (index !== -1) {
            state.students.splice(index, 1, student);
        }
        state.model = {
            Student_id: 0,
            Ime: "",
            Prezime: "",
            Godina: "",
            BrojIndeksa: "",
            StatusStudenta: 1
        }
    }

};
export default {
    state,
    getters,
    actions,
    mutations
}; 