import React, { useMemo, useState } from "react";
import {
    Box, Button, IconButton, Paper, Dialog,
    DialogTitle, DialogContent, DialogActions, Typography, Table, TableHead,
    TableRow, TableCell, TableBody, Stack,
    Container
} from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete";
import AddIcon from "@mui/icons-material/Add";
import { PeriodFormDialog } from "./PeriodFormDialog";
import { enqueueSnackbarError, useAppDispatch, useAppSelector } from "src/core";
import { ContractsUserRoleType, PeriodsGetPeriod, useDeleteApiPeriodsDeleteMutation, useLazyGetApiPeriodsGetQuery, usePostApiPeriodsCreateMutation } from "src/api/backendApi";
import { loadPeriods } from "./period.service";

type PendingDelete = { id: string; name: string } | null;

function formatRange(start: string, end: string) {
    return `${start} — ${end}`;
}

export const PeriodsPage: React.FC = () => {
    const user = useAppSelector((state) => state.auth.user);

    const dispatch = useAppDispatch();
    const periods = useAppSelector((state) => state.period.Periods);

    const [formOpen, setFormOpen] = useState(false);

    const [deleteTarget, setDeleteTarget] = useState<PendingDelete>(null);

    const [fetchCreate, { }] = usePostApiPeriodsCreateMutation();
    const [fetchDelete, { }] = useDeleteApiPeriodsDeleteMutation();
    const [fetchPeriods, { }] = useLazyGetApiPeriodsGetQuery();

    const openCreate = () => {
        setFormOpen(true);
    };

    const handleSubmit = async (values: Omit<PeriodsGetPeriod, "id">) => {
        const response = await fetchCreate({ periodsCreateRequest: { name: values.name, from: values.from, to: values.to } });
        if (response.error) {
            enqueueSnackbarError(response.error);
            return;
        }
        await loadPeriods(dispatch, fetchPeriods);
    };

    const confirmDelete = (p: PeriodsGetPeriod) => {
        setDeleteTarget({ id: p.id, name: p.name });
    };

    const doDelete = async () => {
        if (!deleteTarget) return;
        const { id } = deleteTarget;
        try {
            await fetchDelete({ id });
            await loadPeriods(dispatch, fetchPeriods);
        } catch (e: any) {
            enqueueSnackbarError(e);
        } finally {
            setDeleteTarget(null);
        }
    };

    const sortedPeriods = useMemo(
        () => [...periods].sort((a, b) => (a.from < b.from ? 1 : -1)),
        [periods]
    );

    const canCreate =
        user?.role === ContractsUserRoleType.Deanery
        || user?.departmentHead;

    const canDelete = canCreate;

    return (
        <Container sx={{ display: 'flex', flexDirection: 'column', gap: 1 }} maxWidth="md">

            <Paper className="p-6">
                <Stack direction="row" alignItems="center" justifyContent="space-between" sx={{ mb: 2 }}>
                    <Typography variant="h5">Учебные периоды</Typography>
                    {
                        canCreate &&
                        <Button startIcon={<AddIcon />} variant="contained" onClick={openCreate}>
                            Добавить период
                        </Button>
                    }

                </Stack>
            </Paper>

            <Paper variant="outlined">
                <Table size="small">
                    <TableHead>
                        <TableRow>
                            <TableCell>Название</TableCell>
                            <TableCell>Даты</TableCell>
                            <TableCell align="right">Действия</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {sortedPeriods.map((p) => (
                            <TableRow key={p.id} hover>
                                <TableCell>{p.name}</TableCell>
                                <TableCell>{formatRange(p.from, p.to)}</TableCell>
                                <TableCell align="right">
                                    {
                                        canDelete &&
                                        <IconButton aria-label="Удалить" color="error" onClick={() => confirmDelete(p)}>
                                            <DeleteIcon />
                                        </IconButton>
                                    }
                                </TableCell>
                            </TableRow>
                        ))}
                        {sortedPeriods.length === 0 && (
                            <TableRow>
                                <TableCell colSpan={4}>
                                    <Box sx={{ p: 3, textAlign: "center", color: "text.secondary" }}>
                                        Периодов пока нет. Нажмите «Добавить период».
                                    </Box>
                                </TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </Paper>

            <PeriodFormDialog
                open={formOpen}
                onClose={() => setFormOpen(false)}
                onSubmit={handleSubmit}
                initial={null}
                existing={periods}
            />

            <Dialog open={Boolean(deleteTarget)} onClose={() => setDeleteTarget(null)}>
                <DialogTitle>Удалить период?</DialogTitle>
                <DialogContent>
                    <Typography>
                        Действие необратимо. Удалить «{deleteTarget?.name}»?
                    </Typography>
                </DialogContent>
                <DialogActions>
                    <Button onClick={() => setDeleteTarget(null)}>Отмена</Button>
                    <Button color="error" variant="contained" onClick={doDelete}>Удалить</Button>
                </DialogActions>
            </Dialog>
        </Container>
    );
};
