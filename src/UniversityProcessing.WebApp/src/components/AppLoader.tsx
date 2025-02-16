import { Box, CircularProgress, Modal, Typography } from '@mui/material';

const AppLoader = () =>
  (
    <Modal open={true}
           className="flex flex-col h-full w-full justify-center items-center text-center text-2xl font-bold">
      <Box sx={{ width: 400, padding: 7, bgcolor: 'white', margin: '100px auto' }}>
        <CircularProgress size="3rem" />
        <Typography sx={{ pt: 3 }}>Загрузка...</Typography>
      </Box>
    </Modal>
  );

export default AppLoader;