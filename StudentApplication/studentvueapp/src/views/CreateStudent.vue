<template>
    <div class="container">
        <button class="back" @click="$router.go(-1)"> &#8678; </button>
        <h1>Dodavanje studenta</h1>
        <p>Izaberite studenta za izmjenu podataka. Za unos novog studenta polje <strong>Student </strong>ostavite prazno</p>

        <div id="CreateStudent">
            <ValidationObserver v-slot="{ invalid }">
                <form @submit="onSubmit">

                    <label for="IdStudenta"><b>Student</b></label>
                    <select v-model="model.Student_id" @change="fillData($event)">
                        <option></option>
                        <option v-bind:key="student.Student_id" v-for="student in allStudents" :value="student.Student_id">{{student.Ime}} {{student.Prezime}}</option>
                    </select>
                    <div >
                        <label for="BrojIndeksa"><b>Broj indeksa</b></label>
                        <ValidationProvider name="BrojIndeksa" rules="required" v-slot="{ errors }">
                            <input type="text" v-model="model.BrojIndeksa" placeholder="Unesite broj indeksa">
                            <span class="required">{{ errors[0] }}</span>
                        </ValidationProvider>

                        <label for="ime"><b>Ime</b></label>
                        <input type="text" v-model="model.Ime" placeholder="Unesite ime">

                        <label for="prezime"><b>Prezime</b></label>
                        <input type="text" v-model="model.Prezime" placeholder="Unesite prezime">

                        <label for="godina"><b>Godina</b></label>
                        <input type="text" v-model="model.Godina" placeholder="Unesite godinu studija">

                        <label for="StatusStudenta"><b>Status studenta</b></label>
                        <ValidationProvider name="StatusStudenta" rules="required" v-slot="{ errors }">
                            <select v-model="model.StatusStudenta" required>
                                <option value="" disabled selected>Izaberite status studenta</option>
                                <option value="1">Redovan</option>
                                <option value="2">Vanredan</option>
                            </select>
                            <span class="required">{{ errors[0] }}</span>
                        </ValidationProvider>

                        <div class="clearfix">
                            <button type="submit" class="savebtn" :disabled="invalid">Sačuvaj podatke</button>
                            <button type="reset" class="cancelbtn" @click="reset">Odustani</button>

                        </div>
                    </div>
                </form>
                </ValidationObserver>
        </div>
    </div>

</template>
<script>
    import { mapActions, mapGetters, mapState } from 'vuex';
    import { ValidationProvider, extend, ValidationObserver } from 'vee-validate';
    import { required } from 'vee-validate/dist/rules';

    extend('required', {
        ...required,
        message: 'Ovo polje je obavezno!'
    });

    export default {
        name: "CreateStudent",
        data() {
          return {
                update: false
          }
        },
        components: {
            ValidationProvider,
            ValidationObserver
        },
        methods: {
            ...mapActions(["addStudent", "getStudents", "getStudent", "updateStudent"]),

            fillData(event) {
                if (event.target.value) {
                    const id = event.target.value;
                    this.getStudent(id);
                    this.update = true;
                }
                else this.update = false;
            },
            onSubmit() {
                if (this.update==true) {
                    this.updateStudent();
                    this.reset();
                    this.$alert('Podaci su sačuvani!');
                    
                    this.$router.go(-1);

                }
                else {
                    this.Student_id = "DEFAULT";
                    this.addStudent();
                    this.$alert('Podaci su sačuvani!');
                }
                
            },
            reset() {
                this.model.Student_id = 0;
                this.model.Ime = "";
                this.model.Prezime = "";
                this.model.Godina= "",
                this.model.BrojIndeksa = "";
                this.model.StatusStudenta = 1;
            }
        },
        computed: {
            ...mapGetters(["allStudents"]),
            ...mapState({
                model: (state) => state.Student.model,
            }), 
            
        },
        created() {
            this.getStudents();
            if (this.$route.params.id) {
                this.getStudent(this.$route.params.id);
                this.update = true;
            }
        }
    }

</script>
<style >

    input, select {
        width: 100%;
        padding: 15px;
        margin: 5px 0 22px 0;
        display: inline-block;
        border: none;
        background: #f1f1f1;
        font-size: large;
    }
    input[type=text]:focus {
        background-color: #ddd;
        outline: none;
    }

    hr {
        border: 1px solid #f1f1f1;
        margin-bottom: 25px;
    }
    label {
        float: left;
    }
     button:hover {
            opacity: 1;
     }
    
    .cancelbtn {
       
        background-color: #f44336;
    }
    .required {
        color:red;
    }
    .container {
        padding: 16px;
    }
</style>