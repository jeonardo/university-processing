import { Button, Dialog, DialogActions, DialogContent, DialogTitle, Typography } from '@mui/material';
import CheckCircleOutlineIcon from '@mui/icons-material/CheckCircleOutline';
import { useNavigate } from 'react-router-dom';

const RegisterResultModal = () => {
  const navigate = useNavigate();

  return (
    <Dialog open={true} onClose={() => {
    }} maxWidth="xs" fullWidth>
      <DialogTitle sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
        <CheckCircleOutlineIcon color="success" />
        Регистрация прошла успешно
      </DialogTitle>
      <DialogContent>
        <Typography>
          Ваша учетная запись была успешно создана. Теперь вы можете войти в систему, используя свои учетные данные.
        </Typography>
      </DialogContent>
      <DialogActions>
        <Button onClick={() => navigate('/signin', {})} variant="contained" fullWidth>
          Вернуться
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default RegisterResultModal;