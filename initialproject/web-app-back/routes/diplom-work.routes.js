const express = require("express");
const router = express.Router(); // express.Router()
const verify = require('../verifyToken')
const pool = require("../config/db");

const ALL_DIPLOM_WORK = `SELECT id_diplom_work, name, id_status, id_student, id_leader, mark FROM diplom_work`
const DIPLOM_WORK_BY_ID_LECTOR = `SELECT name, id_status, id_student, id_leader, mark FROM diplom_work WHERE id_leader = $1`
const UPDATE_LEADER_ID = `UPDATE diplom_work SET id_leader = $1 WHERE id_diplom_work = $2`;
const UPDATE_STATUS = `UPDATE diplom_work SET id_status = 'BUSY' WHERE id_diplom_work = $1`;
const ALL_DIPLOM_WORK_WITH_INFO = `SELECT dw.id_diplom_work, dw.name, dw.id_status, us.user_second_name ||' '|| 
    LEFT(us.user_first_name,1) || '.'|| LEFT(us.user_middle_name,1) || '.' initials_student, ul.user_second_name ||' '||
    LEFT(ul.user_first_name,1) || '.'|| LEFT(ul.user_middle_name,1) || '.' initials_lectors FROM diplom_work dw LEFT 
    JOIN lectors l ON dw.id_leader = l.lector_id LEFT JOIN students s ON dw.id_student = s.student_id LEFT JOIN users us 
    ON s.user_id = us.user_id LEFT JOIN users ul ON l.user_id = ul.user_id `
const ALL_FREE_BY_STUDENTS = `SELECT dw.id_diplom_work, dw.name, dw.id_status, dw.id_student, ul.user_second_name 
    ||' '|| LEFT(ul.user_first_name,1) || '.'|| LEFT(ul.user_middle_name,1) || '.' initials_lectors FROM diplom_work dw
    LEFT JOIN lectors l ON dw.id_leader = l.lector_id LEFT JOIN users ul ON l.user_id = ul.user_id`

router.get('/all', async (req, res) => {
  try {
    const diplomWork = await pool.query(ALL_DIPLOM_WORK);
    res.json(diplomWork.rows)
  } catch (error) {
    console.log(error.message)
  }
});

router.get('/', async (req, res) => {
  try {
    const diplomWork = await pool.query(ALL_DIPLOM_WORK_WITH_INFO);
    res.json(diplomWork.rows)
  } catch (error) {
    console.log(error.message)
  }
});

router.get('/free_students', async (req, res) => {
  try {
    const diplomWork = await pool.query(ALL_FREE_BY_STUDENTS);
    res.json(diplomWork.rows)
  } catch (error) {
    console.log(error.message)
  }
});

router.get('/:leaderId', async (req, res) => {
  try {
    const {leaderId} = req.params;
    const diplomWork = await pool.query(DIPLOM_WORK_BY_ID_LECTOR, [leaderId]);
    res.json(diplomWork.rows)
  } catch (error) {
    console.log(error.message)
  }
});

router.put('/book_theme', verify, async(req,res) => {
  try {
    const {leaderId, diplomaId} = req.body;
    await pool.query(UPDATE_LEADER_ID, [leaderId, diplomaId]);
  } catch (error) {
    console.log(error.message)
  }
})

router.put('/update_status', verify, async(req,res) => {
  try {
    const {diplomaId} = req.body;
    await pool.query(UPDATE_STATUS, [diplomaId]);
  } catch (error) {
    console.log(error.message)
  }
})

module.exports = router
