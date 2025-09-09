import React, { useEffect, useMemo, useState } from "react";
import {
    Box, Button, IconButton, Paper, Snackbar, Alert, Dialog,
    DialogTitle, DialogContent, DialogActions, Typography, Table, TableHead,
    TableRow, TableCell, TableBody, Chip, Stack
} from "@mui/material";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import AddIcon from "@mui/icons-material/Add";
import { Period } from "./period";
import { PeriodFormDialog } from "./PeriodFormDialog";

type PendingDelete = { id: string; name: string } | null;

function formatRange(start: string, end: string) {
    return `${start} — ${end}`;
}

export const PeriodsPage: React.FC = () => {
    const [periods, setPeriods] = useState<Period[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    const [formOpen, setFormOpen] = useState(false);
    const [editTarget, setEditTarget] = useState<Period | null>(null);

    const [deleteTarget, setDeleteTarget] = useState<PendingDelete>(null);

    const [snack, setSnack] = useState<{ message: string; severity: "success" | "error" } | null>(null);

    useEffect(() => {
        (async () => {
            try {
                const data = [];
                setPeriods(data);
            } catch (e: any) {
                setError(e?.message || "Не удалось загрузить данные");
            } finally {
                setLoading(false);
            }
        })();
    }, []);

    const openCreate = () => {
        setEditTarget(null);
        setFormOpen(true);
    };

    const openEdit = (p: Period) => {
        setEditTarget(p);
        setFormOpen(true);
    };

    const handleSubmit = async (values: Omit<Period, "id">) => {
        if (editTarget) {
            // const updated = await updatePeriod(editTarget.id, values);
            // setPeriods(prev => prev.map(p => (p.id === updated.id ? updated : p)));
            setSnack({ message: "Период обновлён", severity: "success" });
        } else {
            //  const created = await createPeriod(values);
            //  setPeriods(prev => [created, ...prev]);
            setSnack({ message: "Период создан", severity: "success" });
        }
    };

    const confirmDelete = (p: Period) => {
        setDeleteTarget({ id: p.id, name: p.name });
    };

    const doDelete = async () => {
        if (!deleteTarget) return;
        const { id } = deleteTarget;
        try {
            //  await deletePeriod(id);
            //  setPeriods(prev => prev.filter(p => p.id !== id));
            setSnack({ message: "Период удалён", severity: "success" });
        } catch (e: any) {
            setSnack({ message: e?.message || "Ошибка удаления", severity: "error" });
        } finally {
            setDeleteTarget(null);
        }
    };

    const sortedPeriods = useMemo(
        () => [...periods].sort((a, b) => (a.startDate < b.startDate ? 1 : -1)),
        [periods]
    );

    return (
        <Box sx={{ p: 3 }}>
            <Stack direction="row" alignItems="center" justifyContent="space-between" sx={{ mb: 2 }}>
                <Typography variant="h5">Учебные периоды</Typography>
                <Button startIcon={<AddIcon />} variant="contained" onClick={openCreate}>
                    Добавить период
                </Button>
            </Stack>

            <Paper variant="outlined">
                {loading ? (
                    <Box sx={{ p: 3 }}><Typography>Загрузка...</Typography></Box>
                ) : error ? (
                    <Box sx={{ p: 3 }}><Alert severity="error">{error}</Alert></Box>
                ) : (
                    <Table size="small">
                        <TableHead>
                            <TableRow>
                                <TableCell>Название</TableCell>
                                <TableCell>Даты</TableCell>
                                <TableCell>Статус</TableCell>
                                <TableCell align="right">Действия</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {sortedPeriods.map((p) => (
                                <TableRow key={p.id} hover>
                                    <TableCell>{p.name}</TableCell>
                                    <TableCell>{formatRange(p.startDate, p.endDate)}</TableCell>
                                    <TableCell>
                                        {p.isActive ? <Chip label="Активный" color="success" size="small" /> : <Chip label="Не активный" size="small" />}
                                    </TableCell>
                                    <TableCell align="right">
                                        <IconButton aria-label="Редактировать" onClick={() => openEdit(p)}>
                                            <EditIcon />
                                        </IconButton>
                                        <IconButton aria-label="Удалить" color="error" onClick={() => confirmDelete(p)}>
                                            <DeleteIcon />
                                        </IconButton>
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
                )}
            </Paper>

            <PeriodFormDialog
                open={formOpen}
                onClose={() => setFormOpen(false)}
                onSubmit={handleSubmit}
                initial={editTarget}
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

            <Snackbar
                open={Boolean(snack)}
                autoHideDuration={4000}
                onClose={() => setSnack(null)}
                anchorOrigin={{ vertical: "bottom", horizontal: "center" }}
            >
                {snack ? <Alert severity={snack.severity} onClose={() => setSnack(null)}>{snack.message}</Alert> : <></>}
            </Snackbar>
        </Box>
    );
};
