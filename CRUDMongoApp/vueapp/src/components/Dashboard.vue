<template>
    <div class="hello">
        <Header />
        <div class="container mrgnbtm">
            <div class="row">
                <div class="col-md-8">
                    <CreateUser @createUser="userCreate($event)" @updateUser="updateUser($event)" />
                </div>
                <div class="col-md-4">
                    <DisplayBoard :numberOfUsers="numberOfUsers" @getAllUsers="getUsers()" />
                </div>
            </div>
        </div>
        <div class="row mrgnbtm">
            <Users v-if="users.length > 0" :users="users" @getAllUsers="getUsers()" />
        </div>
    </div>
</template>

<script>
    import Header from './Header.vue'
    import CreateUser from './CreateUser.vue'
    import DisplayBoard from './DisplayBoard.vue'
    import Users from './Users.vue'
    import UserService from '../services/user.service'

    export default {
        name: 'Dashboard',
        components: {
            Header,
            CreateUser,
            DisplayBoard,
            Users
        },
        data() {
            return {
                users: [],
                numberOfUsers: 0
            }
        },
        methods: {
            getUsers() {
                //getAllUsers().then(res => {
                //  this.users = res;
                //  console.log(this.users)
                //  this.numberOfUsers = this.users.length
                //});
                UserService.getAll().then((response) => {
                    this.users = response.data;
                    console.log(response.data);
                    this.numberOfUsers = this.users.length
                }).catch((error) => {
                    console.log(error.response);
                });
            },
            userCreate(data) {
                //  console.log(data);
                //  createUser(data).then(res => {
                //    this.getUsers();
                //    console.log('res:::', res);
                //  });
                UserService.create(data).then((response) => {
                    this.getUsers();
                    console.log(response.data);
                }).catch((error) => {
                    console.log(error.response);
                });
            },
            updateUser(data) {
                UserService.update(data.id, data).then((res) => {
                    this.getUsers();
                }).catch((error) => {
                    console.log(error.response);
                });
            }
        },
        mounted() {
            this.getUsers();
        }
    }
</script>