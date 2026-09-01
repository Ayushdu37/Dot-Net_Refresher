SELECT 
    blocked_req.blocking_session_id AS BlockingSessionId,
    blocking_sess.login_name AS BlockingUser,
    blocking_sess.host_name AS BlockingHost,
    blocking_sess.program_name AS BlockingProgram,
    blocking_text.text AS BlockingSqlText,
    blocked_req.session_id AS BlockedSessionId,
    blocked_sess.login_name AS BlockedUser,
    blocked_req.wait_type AS WaitType,
    blocked_req.wait_time AS WaitTimeMs,
    blocked_text.text AS BlockedSqlText
FROM sys.dm_exec_requests AS blocked_req
JOIN sys.dm_exec_sessions AS blocked_sess 
    ON blocked_req.session_id = blocked_sess.session_id
JOIN sys.dm_exec_sessions AS blocking_sess 
    ON blocked_req.blocking_session_id = blocking_sess.session_id
LEFT JOIN sys.dm_exec_requests AS blocking_req 
    ON blocked_req.blocking_session_id = blocking_req.session_id
OUTER APPLY sys.dm_exec_sql_text(blocked_req.sql_handle) AS blocked_text
OUTER APPLY sys.dm_exec_sql_text(ISNULL(blocking_req.sql_handle, blocking_sess.open_transaction_count)) AS blocking_text
WHERE blocked_req.blocking_session_id <> 0;
