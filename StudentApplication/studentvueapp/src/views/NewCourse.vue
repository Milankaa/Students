<template>
    <div id="NewCourse">
        <form @submit="addCourse(title)">
            <button class="back" @click="$router.go(-1)"> &#8678; </button>
            <h1>Unesite naziv kursa</h1>
            <input type="text" v-model="title" placeholder="Unesite naziv kursa" id="title" />
            <div v-if="visiblebtn">
                <button type="button" @click="onSubmit"> Sačuvaj podatke</button>
                <button type="reset" class="cancel">Odustani</button>
            </div>
            <router-link v-if="visible" :to="{name: 'AddStudentsOnCourse', params:{id: getID, courseTitle:title}}">Dodaj studente</router-link>

        </form>
    </div>
</template>
<script>

    import { mapActions, mapGetters } from 'vuex';

    export default {
        name: 'NewCourse',
        data() {
            return {
                title: "",
                visible: false,
                visiblebtn: true
            }
        },
        methods: {
            ...mapActions(["addCourse", "getCourses"]),
            onSubmit() {
                this.addCourse(this.title);
                this.$alert("Uspješno ste dodali kurs!");
                this.visible = true;
                this.visiblebtn = false;
            }
        },
        computed: {
            ...mapGetters(["allCourses"]),
            getID() {
                var id = this.allCourses[this.allCourses.length-1].ID_kursa+1;
                return id;
            }
        },
        created() {
            this.getCourses();
        }
    };
</script>
<style scoped>
    input {
        width: 100%;
        padding: 15px;
        margin: 5px 0 22px 0;
        display: inline-block;
        border: none;
        background: #f1f1f1;
        font-size:large;
    }
 
    .cancel {
        background-color:red;
    }
</style>