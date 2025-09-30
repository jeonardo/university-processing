# Diploma Processes Feature

This feature provides comprehensive management of diploma processes in the university system.

## Features Implemented

### Core Diploma Process Management
- **Create Diploma Process**: Create new diploma processes with name and period association
- **List Diploma Processes**: View all diploma processes with pagination and search
- **Delete Diploma Process**: Remove diploma processes (with confirmation dialog)

### User Management
- **Add Groups**: Associate groups with diploma processes
- **Add Teachers**: Associate teachers with diploma processes  
- **Remove Groups**: Remove group associations from diploma processes
- **Remove Teachers**: Remove teacher associations from diploma processes

## API Methods Used

All diploma processing methods from `backendApi.ts` are implemented:

1. `getApiDiplomaProcessesGet` - Fetch diploma processes with pagination
2. `postApiDiplomaProcessesCreate` - Create new diploma process
3. `deleteApiDiplomaProcessesDelete` - Delete diploma process
4. `postApiDiplomaProcessesUsersAddGroup` - Add group to diploma process
5. `postApiDiplomaProcessesUsersAddTeacher` - Add teacher to diploma process
6. `postApiDiplomaProcessesUsersRemoveGroup` - Remove group from diploma process
7. `postApiDiplomaProcessesUsersRemoveTeacher` - Remove teacher from diploma process

## Access Control

- **Create/Delete**: Only Deanery users and Department Heads can create/delete diploma processes
- **View**: All authenticated users can view diploma processes
- **User Management**: Only Deanery users and Department Heads can manage participants

## Navigation

The page is accessible at `/diploma-processes` route and is integrated into the main navigation.

## Dependencies

- Uses existing project patterns (AppList, AppListPagination, AppListSearch)
- Integrates with period selection system
- Follows Material-UI design patterns
- Uses RTK Query for API state management

