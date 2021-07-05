<template>
    <div class="container">
        <h2>Users</h2>
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>User Id</th>
                    <th>Firstname</th>
                    <th>Lastname</th>
                    <th>Email</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(item, index) in users" :key="index">
                    <td>{{ index + 1 }}</td>
                    <td>{{ item.firstName }}</td>
                    <td>{{ item.lastName }}</td>
                    <td>{{ item.email }}</td>
                    <td colspan="2"  align="center"><button type="button" @click='viewUser(item)' :disabled="isDisable" class="btn btn-warning">View</button></td>
                    <td align="center"><button type="button" @click='deleteUser(item)' class="btn btn-danger">Delete</button></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import UserService from '../services/user.service'
    import Vuex from 'vuex'

    const store = new Vuex.Store({
        state: {
            userDetail: null;
        },
        mutations: {
            bindUserDetail(state) {
                state.userDetail = item;
            }
        }
    })

    export default {
        name: 'Users',
        props: ['users'],
        data() {
            return {
                isDisable: false,
            }
        },
        methods: {
            viewUser(item) {
                store.commit('bindUserDetail',item);
            },
            deleteUser(item) {
                UserService.delete(item.id).then((res) => {
                    this.$emit('getAllUsers')
                }).catch((error) => {
                    console.log(error.response);
                });
            }
        }
    }
</script>