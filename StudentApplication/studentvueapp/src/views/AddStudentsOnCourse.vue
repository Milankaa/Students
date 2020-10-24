<template>
    <div class="addStudents">
        <form>
            <button class="back" @click="$router.go(-1)"> &#8678; </button>
            <h1>Dodavanje studenata na kurs {{$route.params.courseTitle}}</h1>
            <label for="Student"><b>Studenti</b></label>
            <select v-model="Student_id" placeholder="Izaberite studenta">
                <option v-if="!studentsNotOnCourse.length" disabled>Nema studenata!</option>
                <option v-bind:key="student.Student_id" v-for="student in studentsNotOnCourse" :value="student.Student_id"> {{student.Ime}} {{student.Prezime}} Broj indeksa: {{student.BrojIndeksa}} </option>
            </select>
            <button type="button" @click.prevent="addStudent">Dodaj studenta</button>
        </form>
    </div>
</template>
<script>
    import { mapGetters, mapActions, mapState } from 'vuex';
 
    export default {
        name: 'AddStudentsOnCourse',
        data() {
            return {
                Student_id: 1
            }
        },
        methods: {
            ...mapActions(["getStudents", "addStudentToCourse", "getStudent", "getStudentsOnCourse"]),
            addStudent() {
                const studentCourse = { Student_id: this.Student_id, ID_kursa: this.$route.params.id };
                this.addStudentToCourse(studentCourse);
                this.$alert("Dodali ste studenta!");
            }
        },
        computed: {
            ...mapGetters(["allStudentsOnCourse", "allStudents"]),
            ...mapState({
                model: (state) => state.Student.model,
            }),
            studentsNotOnCourse: function () {
                var all = this.allStudents;
                var onCourse = this.allStudentsOnCourse;
                if (all.length) {
                    return all.filter(
                        function (student) {
                           return !onCourse.some(
                                function (student2) {
                                   return student.Student_id === student2.Student_id;
                                });
                        });
                }
                return this.allStudents;
            }
            
        },
        created() {
            this.getStudents();
            this.getStudentsOnCourse(this.$route.params.id);
        }
    };
</script>
<style scoped>
    select {
        width: 100%;
        padding: 15px;
        margin: 5px 0 22px 0;
        display: inline-block;
        border: none;
        background: #f1f1f1;
    }

    
    option {
        padding: 14px 20px;
        margin: 8px 0;
        border: none;
        cursor: pointer;
        font-size:large;
    }
</style>
