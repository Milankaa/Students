<template>
    <div id="DeleteStudent" class="container">
        <button class="back" @click="$router.go(-1)"> &#8678; </button> 
        <form @submit="delStudent">
            
            <h1>Brisanje studenta</h1>
            <label for="Student"><b>Studenti</b></label>
            <select name="StudentID" v-model="StudentID" placeholder="Izaberite studenta">
                <option v-if="!allStudents.length" disabled>Nema studenata!</option>
                <option value="0"> </option>
                <option v-bind:key="student.Student_id" v-for="student in allStudents" :value="student.Student_id"> {{student.Ime}} {{student.Prezime}} ID: {{student.Student_id}} </option>
            </select>
            <div>
                <button type="submit" class="savebtn">Obriši studenta</button>
                <button type="reset" class="cancel" @click="Reset()" >Odustani</button>
            </div>
        </form>
    </div>
</template>
<script>

    import { mapGetters, mapActions } from 'vuex';
    export default {
        name: 'DeleteStudent',
        data() {
            return {
                StudentID: 1
            }
        },
        methods: {
            ...mapActions(['getStudents', "deleteStudent"]),
            Reset() {
                this.StudentID = 0;
            },
            delStudent() {
                if (this.allStudents.length) {
                    if (confirm("Da li ste sigurni da želite obrisati studenta?")) {
                        this.deleteStudent(this.StudentID);
                        this.$alert("Uspješno ste obrisali studenta!");
                    }
                }
                this.Reset();
                this.getStudents();
            }
    },
        computed: mapGetters(["allStudents"]),
        created() {
            this.getStudents();
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
        font-size:large;
    }

    .cancel {
        background-color: red;
    }
    </style>