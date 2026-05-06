---
marp: true
theme: default
paginate: true
---

<!-- _class: lead -->

# AI Agent Interaction Patterns
## From Ad-hoc to Scalable

**Block 4** - Day 1
Workshop: AI Agents for Software Developers

---

# The "Agent Pattern Problem"

**Scenario:** Remember your Block 3 repository? You fixed 3 issues...
**Now imagine:** You need to fix 50 similar issues across the entire codebase!

**The Challenge:**
- How do I scale beyond one-by-one fixes?
- Which pattern fits which type of task?
- When should I stay simple vs. go complex?

**Our Question Today:**
> What interaction patterns maximize our engineering impact with OpenCode?

---

# The 5 Agent Interaction Patterns

1. **Iterative Human-in-the-Loop (HIL)** ✅ *You've been doing this!*
2. **Reusable Prompts** ✅ *You tried this in Block 2*
3. **Sub-Agent Pattern** 🆕 *New powerful technique*
4. Prompt Workflows with Sub-Agents
5. Wrapper MCP Server

**Today's Journey:** Review what you know, master what's new
**Why?** "Keep it simple, scale when needed"

---

<!-- _class: lead -->

# Pattern 1: Iterative Human-in-the-Loop
## The Controlled Dialogue

---

# Human-in-the-Loop (HIL)

## You've Been Doing This!
```
Human → Prompt → Agent → Service → Outcome → Review → Repeat
```

## Your Block 3 Experience
```bash
opencode-cli "This test fails, find out why and fix it"
# Review the fix
opencode-cli "Now test it like a user would"
# Review test results
opencode-cli "Good, now update the documentation"
```

**Key:** You already mastered this - step-by-step refinement with full control

---

# HIL: Pros and Cons

## ✅ Pros
- **Direct Control** - You see every step
- **High Accuracy** - Immediate feedback
- **Simplicity** - No complex setup
- **Learning Curve** - Ideal for starting

## ⚠️ Cons
- **Human as Bottleneck** - Not scalable
- **Time-Intensive** - For repetitive tasks
- **Context Loss** - In long sessions

---

# HIL: When to Use?

## Perfect for:
- 🐛 **Production Bugs** - Control is critical
- 🔍 **Exploration** - Unknown codebases
- 🎯 **Precise Changes** - Critical business logic
- 📚 **Learning** - Understanding what the agent does

## Real-World Example:
```bash
opencode-cli "This test fails, find out why and fix it"
# Agent analyzes, you review
opencode-cli "Try a different approach"
# Iterate to solution
```

---

<!-- _class: lead -->

# Pattern 2: Reusable Prompts
## Your Personal Toolbox

---

# Reusable Prompts

## You Started This in Block 2!
Remember custom commands? Time to level up!

```bash
# Create custom commands in .opencode/commands/
# explain.md:
"Explain this code in simple terms for a junior developer"

# security.md:
"Check this code for security vulnerabilities (OWASP Top 10)"

# Use them with slash commands:
opencode-cli "/explain complex_algorithm.js"
opencode-cli "/security user_auth.py"
```

---

# Reusable Prompts: Pros and Cons

## ✅ Pros
- **Consistency** - Same quality every time
- **Efficiency** - No prompt repetition
- **Team Sharing** - Share best practices
- **Version Control** - Git-trackable prompts

## ⚠️ Cons
- **Initial Setup** - Time to craft good prompts
- **Maintenance** - Prompts need upkeep
- **Abstraction Layer** - One more layer

---

# Reusable Prompts: Practical Examples

## Your Command Library (.opencode/commands/)
```markdown
# review.md
Review like a senior dev: readability, performance, security

# document.md
Add JSDoc with examples and edge cases

# test-edge.md
Find edge cases and write tests for them

# modernize.md
Refactor to modern ES6+ patterns
```

**Usage:** `/review`, `/document`, `/test-edge`, `/modernize`
**Pro Tip:** Start with 3-5 commands you need daily!

---

<!-- _class: lead -->

# Pattern 3: Sub-Agent Pattern
## Specialized Agents for Scalable Solutions

---

# Sub-Agent Pattern

## The Concept
A primary agent coordinates specialized sub-agents

```bash
opencode-cli "Break down this migration into subtasks and execute them"

# OpenCode automatically creates:
# → Database Migration Agent
# → Code Refactoring Agent
# → Test Update Agent
# → Documentation Agent
```

**Parallel instead of sequential!**

---

# Sub-Agent: Pros and Cons

## ✅ Pros
- **Parallelization** - Multiple tasks simultaneously
- **Specialization** - Each agent an expert
- **Scaling** - From 1 to N agents
- **Reusability** - Agents for similar tasks

## ⚠️ Cons
- **Complexity** - Harder to debug
- **Gray Box Problem** - What's the sub-agent doing?
- **Information Flow** - Coordination needed
- **Token-Intensive** - More context = more cost

---

# Sub-Agent: When to Use?

## Perfect for:
- 🔄 **Large Refactorings** - Many files in parallel
- 🧪 **Test Generation** - Tests for multiple modules
- 📊 **Data Migration** - Parallel transformations
- 🌍 **Multi-Language** - Frontend + Backend simultaneously

## Example:
```bash
opencode-cli "Migrate all our API endpoints from v1 to v2 format.
Use parallel agents for each endpoint group."
```

---

# Decision Framework

## "Keep it simple, scale when needed"

| Situation | Pattern | Why? |
|-----------|---------|------|
| Bug in Production | HIL | Control critical |
| Daily Code Reviews | Reusable | Consistency matters |
| Large Migration | Sub-Agent | Parallelization needed |
| Exploration | HIL | Learn & Understand |
| Team Standards | Reusable | Uniform quality |

**Rule:** Start with HIL → Recognize Patterns → Scale when needed

---

# The Next Patterns (Preview)

## 4. Prompt Workflows with Sub-Agents
- Complete workflows as prompts
- Suite of specialized agents
- For: Complex, multi-stage processes

## 5. Wrapper MCP Server
- Dedicated server as interface
- Direct API/Service integration
- For: Enterprise integration

**Today:** Focus on the basics you can use immediately!

---

# Key Takeaways

## 🎯 Main Messages

1. **Start Simple** - HIL for new tasks
2. **Pattern Recognition** - Identify repetitions
3. **Scale Smart** - Only when really necessary
4. **Document Patterns** - Build team knowledge

## 💡 Remember:
> "Most problems are solved with HIL and Reusable Prompts.
> Sub-Agents are the Swiss Army knife for complex tasks."

---

# Time for Practice!

## Your 45-Minute Journey

### Round 1: Human-in-the-Loop (15 min)
- Start with calculator example
- Build iteratively with reviews
- Notice how context builds

### Round 2: Custom Commands (15 min)
- Create 3 commands in `.opencode/commands/`
- Test them on your code
- Share your best command with the team

### Round 3: Sub-Agent Pattern (15 min)
- Use the Task tool for parallel work
- Try the examples from your handout
- Compare speed vs. sequential approach

**📖 Follow your handout for detailed instructions!**

---

<!-- _class: lead -->

# Let's Practice!

## 45 Minutes Hands-On

**Work in your teams**
**Use your Block 3 repos**
**Ask for help anytime**

Ready? Let's go! 🚀