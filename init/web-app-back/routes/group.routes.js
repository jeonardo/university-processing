const express = require("express");
const router = express.Router();
const verify = require('../verifyToken')
const pool = require("../config/db");
const groupController = require("../controllers/group.controller.js");

const ALL_GROUPS = `SELECT g.group_id, g.group_name, g.fk_specialty, s.specialty_id , s.specialty_name FROM groups g 
                    JOIN specialty s ON s.specialty_id = g.fk_specialty`;
const ALL_GROUPS_BY_CATHEDRA = `SELECT g.group_id, g.group_name, g.fk_specialty, s.specialty_id , s.specialty_name FROM groups g 
                    JOIN specialty s ON s.specialty_id = g.fk_specialty WHERE s.fk_cathedra = $1`;
const UPDATE_GROUP = `UPDATE groups SET group_name = $1, fk_specialty=$2 WHERE group_id =$3`;
const ADD_GROUP = `INSERT INTO groups(group_name, fk_specialty) VALUES ($1,$2)`;
const DELETE_GROUP = `DELETE FROM groups WHERE group_id = $1`;


router.get('/all', async (req, res) => {
    //console.log("hi index")
    try {
        const data = await pool.query(ALL_GROUPS);
        res.json(data.rows)
    } catch (error) {
        console.log(error.message)
    }
});

router.get('/all/:id', verify, async (req, res) => {
    try {
        const {id} = req.params;
        const data = await pool.query(ALL_GROUPS_BY_CATHEDRA, [id]);
        res.json(data.rows)
        console.log(data.rows)
    } catch (error) {
        console.log(error.message)
    }
});

//TODO: ADD verify
router.put('/update', async(req,res) => {
    try {
        const group = req.body;
        await pool.query(UPDATE_GROUP, [group.group_name, group.fk_specialty, group.group_id]);
        res.json('group was update')
    } catch (error) {
        console.log(error.message)
    }
})

//TODO: ADD verify
router.post('/create', async (req, res) => {
    try {
        const group = req.body;
        await pool.query(ADD_GROUP, [group.group_name, group.fk_specialty])
        res.json('date was posted')
    } catch (error) {
      console.log(error.message)
    }
});


router.delete('/:id', verify, async(req, res) => {
    try {
        const id = req.params;
        await pool.query(DELETE_GROUP, [id]);
        res.json('group was deleted')
    } catch (error) {
        console.log(error.message)
    }
});


module.exports = router
